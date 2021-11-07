using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class DatabaseSelectionModalPatcher
    {
        [HarmonyPatch(typeof(DatabaseSelectionModal), "BuildMonsters")]
        internal static class DatabaseSelectionModal_BuildMonsters_Patch
        {
            internal static bool Prefix(DatabaseSelectionModal __instance)
            {
                if (Main.Settings.UnleashAllMonsters)
                {
                    var isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

                    __instance.allMonsters.Clear();
                    foreach (MonsterDefinition allElement in DatabaseRepository.GetDatabase<MonsterDefinition>().GetAllElements())
                    {
                        if (!allElement.GuiPresentation.Hidden)
                            __instance.allMonsters.Add(allElement);
                    }
                    __instance.allMonsters.Sort((IComparer<MonsterDefinition>)__instance);

                    return false;
                }

                return true;
            }
        }

        // this patch unleashes all monster definitions to be used as NPCs
        [HarmonyPatch(typeof(DatabaseSelectionModal), "BuildNpcs")]
        internal static class DatabaseSelectionModal_BuildNpcs_Patch
        {
            internal static bool Prefix(DatabaseSelectionModal __instance)
            {
                if (Main.Settings.UnleashAllNPCs)
                {
                    var isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

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