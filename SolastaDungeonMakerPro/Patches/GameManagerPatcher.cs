using HarmonyLib;
using UnityEngine.UI;

namespace SolastaDungeonMakerPro.Patches
{
    internal static class GameManagerPatcher
    {
        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {   
            internal static void Postfix()
            {
                Main.Enabled = true;

                Models.DungeonEditorContext.UpdateAvailableDungeonSizes();

                Models.DungeonEditorContext.LoadFlatRooms();

                Models.DungeonEditorContext.UpdateCategories();

                Models.DungeonEditorContext.UpdateGadgetsPlacement();
                Models.DungeonEditorContext.UpdatePropsPlacement();

                Models.DungeonEditorContext.UnleashGadgetsOnAllEnvironments();
                Models.DungeonEditorContext.UnleashPropsOnAllEnvironments();
                Models.DungeonEditorContext.UnleashRoomsOnAllEnvironments();

                Models.DungeonEditorClipboardContext.Init();

                Models.EncountersSpawnContext.RegisterSpawnCommand();

                Models.ScriptingContext.AddLuaScriptGadget();

                Models.TelemaCampaignContext.Load();

                Models.MonsterContext.AddNewMonsters();
            }
        }
    }

    [HarmonyPatch(typeof(MainMenuScreen), "OnBeginShow")]
    internal static class _
    {
        internal static void Prefix(Toggle ___multiplayerToggle)
        {
            ___multiplayerToggle?.gameObject.SetActive(true);
        }
    }
}