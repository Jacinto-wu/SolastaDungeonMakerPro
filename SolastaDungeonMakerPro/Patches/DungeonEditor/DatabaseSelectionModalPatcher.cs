using HarmonyLib;
using System.Collections.Generic;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class DatabaseSelectionModalPatcher
    {
        //[HarmonyPatch(typeof(DatabaseSelectionModal), "BuildMonsters")]
        //internal static class DatabaseSelectionModal_BuildMonsters_Patch
        //{
        //    internal static bool Prefix(DatabaseSelectionModal __instance)
        //    {
        //        if (Main.Settings.UnleashAllMonsters)
        //        {
        //            __instance.allMonsters.Clear();
        //            foreach (MonsterDefinition allElement in DatabaseRepository.GetDatabase<MonsterDefinition>().GetAllElements())
        //            {
        //                if (!allElement.GuiPresentation.Hidden)
        //                    __instance.allMonsters.Add(allElement);
        //            }
        //            __instance.allMonsters.Sort((IComparer<MonsterDefinition>)__instance);

        //            return false;
        //        }

        //        return true;
        //    }
        //}

        // this patch unleashes all monster definitions to be used as NPCs
        [HarmonyPatch(typeof(DatabaseSelectionModal), "BuildNpcs")]
        internal static class DatabaseSelectionModal_BindItem_Patch
        {
            internal static bool Prefix(DatabaseSelectionModal __instance)
            {
                if (Main.Settings.UnleashAllNPCs)
                {
                    __instance.allNpcs.Clear();
                    foreach (MonsterDefinition allElement in DatabaseRepository.GetDatabase<MonsterDefinition>().GetAllElements())
                    {
                        if (!allElement.GuiPresentation.Hidden)
                            __instance.allNpcs.Add(allElement);
                    }
                    __instance.allNpcs.Sort((IComparer<MonsterDefinition>)__instance);

                    return false;
                }

                return true;
            }
        }
    }
}