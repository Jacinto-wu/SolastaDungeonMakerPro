using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    class GameLocationPositioningManagerPatch
    {
        // hack to avoid a trace message when party greater than 4
        [HarmonyPatch(typeof(GameLocationPositioningManager), "CharacterMoved", new Type[] { typeof(GameLocationCharacter), typeof(TA.int3), typeof(TA.int3), typeof(RulesetActor.SizeParameters), typeof(RulesetActor.SizeParameters) })]
        internal static class GameLocationPositioningManager_CharacterMoved_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var logErrorMethod = typeof(Trace).GetMethod("LogError", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder, new Type[1] { typeof(string) }, null);
                int found = 0;

                foreach (var instruction in instructions)
                {
                    if (instruction.Calls(logErrorMethod) && ++found == 1)
                    {
                        yield return new CodeInstruction(OpCodes.Pop);
                    }
                    else
                    {
                        yield return instruction;
                    }
                }
            }     
        }
    }
}