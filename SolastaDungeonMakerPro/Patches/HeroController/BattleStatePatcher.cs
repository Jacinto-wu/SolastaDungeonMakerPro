using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.Controller
{
    // this patch initiates / shutdowns the HeroesAi and EnemyController systems
    class BattleStatePatcher
    {
        [HarmonyPatch(typeof(BattleState_TurnInitialize), "Begin")]
        internal static class BattleState_TurnInitialize_Begin_Patch
        {
            internal static void Prefix()
            {
                Models.HeroControllerContext.Start();
            }
        }

        [HarmonyPatch(typeof(BattleState_TurnEnd), "Begin")]
        internal static class BattleState_TurnEnd_Begin_Patch
        {
            internal static void Prefix()
            {
                Models.HeroControllerContext.Stop();
            }
        }

        [HarmonyPatch(typeof(BattleState_Victory), "Begin")]
        internal static class BattleState_Victory_Begin_Patch
        {
            internal static void Prefix(BattleState_Victory __instance)
            {
                Models.HeroControllerContext.Stop();
            }
        }
    }
}