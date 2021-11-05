using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.EncountersSpawn
{
    // use this patch to stage the encounter on the desired location
    class GameLocationScreenBattlePatcher
    {
        [HarmonyPatch(typeof(GameLocationScreenBattle), "HandleInput")]
        internal static class GameLocationScreenBattle_HandleInput_Patch
        {
            internal static bool Prefix(InputCommands.Id command, ref bool __result)
            {
                if (command == Settings.CTRL_SHIFT_E && Models.EncountersSpawnContext.EncounterCharacters.Count > 0)
                {
                    Models.EncountersSpawnContext.ConfirmStageEncounter();
                    __result = true;
                    return false;
                }
                return true;
            }
        }
    }
}