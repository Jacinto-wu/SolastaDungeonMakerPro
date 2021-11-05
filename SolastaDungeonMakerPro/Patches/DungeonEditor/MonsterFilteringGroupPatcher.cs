using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using ModKit;

namespace SolastaDungeonMakerPro.Patches
{
    public static class MonsterFilteringGroupPatcher
    {
        [HarmonyPatch(typeof(MonsterFilteringGroup), "BuildToggles")]
        internal static class GadgetBlueprintSelectionPanel_Compare_Patch
        {
            internal static void Postfix(MonsterFilteringGroup __instance, Transform ___filtersTable, GameObject ___filterTogglePrefab, List<DatabaseFilterToggle> ___familyToggles)
            {
                if (Main.Settings.EnableCustomMonsters)
                {
                    Gui.GetPrefabFromPool(___filterTogglePrefab, ___filtersTable);
                    Transform child = ___filtersTable.GetChild(___filtersTable.childCount - 1);
                    DatabaseFilterToggle component = child.GetComponent<DatabaseFilterToggle>();
                    child.name = "ModdedToggle";
                    component.Bind("Modded", "[MODDED]".red(), new DatabaseFilterToggle.FilterToggleChangedHandler(__instance.FamilyToggleChanged), true);
                    ___familyToggles.Add(component);
                }
            }
        }

        [HarmonyPatch(typeof(MonsterFilteringGroup), "Refresh")]
        internal static class MonsterFilteringGroup_Refresh_Patch
        {
            internal static bool Prefix(
                MonsterFilteringGroup __instance,
                List<MonsterDefinition> ___monstersList,
                List<MonsterDefinition> ___filteredMonstersList,
                ref bool ___refreshing,
                string ___keyword,
                string ___currentFamily,
                bool ___showCustom,
                bool notify = true)
            {
                if (Main.Settings.EnableCustomMonsters && ___monstersList != null)
                {
                    ___refreshing = true;
                    ___filteredMonstersList.Clear();
                    foreach (MonsterDefinition monster in ___monstersList)
                    {
                        if (string.IsNullOrEmpty(___keyword) || Gui.Localize(monster.GuiPresentation.Title).ToUpper().Contains(___keyword) && (___showCustom || !monster.UserMonster))
                        {
                            if (___currentFamily == "All")
                                ___filteredMonstersList.Add(monster);
                            else if (___currentFamily == "Custom" && monster.UserMonster)
                                ___filteredMonstersList.Add(monster);
                            else if (monster.CharacterFamily == ___currentFamily)
                                ___filteredMonstersList.Add(monster);
                            else if (___currentFamily == "Modded" && Models.MonsterContext.ModdedMonsters.Contains(monster))
                                ___filteredMonstersList.Add(monster);
                        }
                    }
                    if (notify)
                    {
                        __instance.MonstersFiltered?.Invoke(___filteredMonstersList);
                    }
                    __instance.RefreshSearchButtons();
                    ___refreshing = false;

                    return false;
                }

                return true;
            }
        }
    }
}