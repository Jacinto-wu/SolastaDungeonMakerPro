using HarmonyLib;
using System.Collections.Generic;

namespace SolastaDungeonMakerPro.Patches.Scripting
{
    // this patch initiates / shutdowns the HeroesAi and EnemyController systems
    class BattleStatePatcher
    {
        [HarmonyPatch(typeof(BattleState_Intro), "Begin")]
        internal static class BattleState_Intro_Begin_Patch
        {
            internal static void Prefix()
            {
                var scriptingContext = new Models.ScriptingContext();
                var gameLocationBattleService = ServiceRepository.GetService<IGameLocationBattleService>();
                var contenders = new List<GameLocationCharacter>
                {
                    gameLocationBattleService.Battle.ActiveContender
                };

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: on_battle_start - actors: {gameLocationBattleService.Battle.AllContenders.Count}");
                }

                contenders.AddRange(gameLocationBattleService.Battle.AllContenders);
                scriptingContext.RunLuaEvent("on_battle_start", gameLocationBattleService.Battle, contenders).ExecuteUntilDone();
            }
        }

        [HarmonyPatch(typeof(BattleState_RoundStart), "Begin")]
        internal static class BattleState_RoundStart_Begin_Patch
        {
            internal static void Prefix()
            {
                var scriptingContext = new Models.ScriptingContext();
                var gameLocationBattleService = ServiceRepository.GetService<IGameLocationBattleService>();
                var contenders = new List<GameLocationCharacter>
                {
                    gameLocationBattleService.Battle.ActiveContender
                };

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: on_round_start - actors: {gameLocationBattleService.Battle.AllContenders.Count}");
                }

                contenders.AddRange(gameLocationBattleService.Battle.AllContenders);
                scriptingContext.RunLuaEvent("on_round_start", gameLocationBattleService.Battle, contenders).ExecuteUntilDone();
            }
        }

        [HarmonyPatch(typeof(BattleState_TurnInitialize), "Begin")]
        internal static class BattleState_TurnInitialize_Begin_Patch
        {
            internal static void Prefix()
            {
                var scriptingContext = new Models.ScriptingContext();
                var gameLocationBattleService = ServiceRepository.GetService<IGameLocationBattleService>();
                var contenders = new List<GameLocationCharacter>
                {
                    gameLocationBattleService.Battle.ActiveContender
                };

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: on_turn_start - actors: {gameLocationBattleService.Battle.AllContenders.Count}");
                }

                contenders.AddRange(gameLocationBattleService.Battle.AllContenders);
                scriptingContext.RunLuaEvent("on_turn_start", gameLocationBattleService.Battle, contenders).ExecuteUntilDone();
            }
        }

        [HarmonyPatch(typeof(BattleState_TurnEnd), "Begin")]
        internal static class BattleState_TurnEnd_Begin_Patch
        {
            internal static void Prefix()
            {
                var scriptingContext = new Models.ScriptingContext();
                var gameLocationBattleService = ServiceRepository.GetService<IGameLocationBattleService>();
                var contenders = new List<GameLocationCharacter>
                {
                    gameLocationBattleService.Battle.ActiveContender
                };

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: on_turn_end - actors: {gameLocationBattleService.Battle.AllContenders.Count}");
                }

                contenders.AddRange(gameLocationBattleService.Battle.AllContenders);
                scriptingContext.RunLuaEvent("on_turn_end", gameLocationBattleService.Battle, contenders).ExecuteUntilDone();
            }
        }

        [HarmonyPatch(typeof(BattleState_Victory), "Begin")]
        internal static class BattleState_Victory_Begin_Patch
        {
            internal static void Prefix(BattleState_Victory __instance)
            {
                var scriptingContext = new Models.ScriptingContext();
                var gameLocationBattleService = ServiceRepository.GetService<IGameLocationBattleService>();
                var contenders = new List<GameLocationCharacter>
                {
                    gameLocationBattleService.Battle.ActiveContender
                };

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: on_battle_end - actors: {gameLocationBattleService.Battle.AllContenders.Count}");
                }

                contenders.AddRange(gameLocationBattleService.Battle.AllContenders);
                scriptingContext.RunLuaEvent("on_battle_end", gameLocationBattleService.Battle, contenders).ExecuteUntilDone();
            }
        }
    }
}