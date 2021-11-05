using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.Controller
{
    class GameLocationBattlePatcher
    {
        [HarmonyPatch(typeof(GameLocationBattle), "CheckVictoryOrDefeat")]
        internal static class GameLocationBattle_CheckVictoryOrDefeat_Patch
        {
            internal static void Prefix()
            {
                Models.HeroControllerContext.Stop();
            }
        }
    }
}