using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.Controller
{
    class GameLocationCharacterManagerPatcher
    {
        [HarmonyPatch(typeof(GameLocationCharacterManager), "KillCharacter")]
        internal static class GameLocationCharacterManager_KillCharacter_Patch
        {
            internal static void Prefix()
            {
                Models.HeroControllerContext.Stop();
            }
        }
    }
}