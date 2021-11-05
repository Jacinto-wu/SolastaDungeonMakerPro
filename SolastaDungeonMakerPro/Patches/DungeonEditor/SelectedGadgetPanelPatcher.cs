using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using ModKit;
using System.Reflection.Emit;

namespace SolastaDungeonMakerPro.Patches
{
    public static class SelectedGadgetPanelPatcher
    {
        [HarmonyPatch(typeof(SelectedGadgetPanel), "Bind")]
        public static class SelectedGadgetPanel_Bind_Patch
        {
            public static string Convert(string str, UserGadget userGadget)
            {
                if (userGadget.GadgetBlueprint.name.StartsWith("Monster") && Models.MonsterContext.ModdedMonsters.Exists(x => x.Name == userGadget.ParameterValues[0].StringValue))
                {
                    return str.red();
                }
                return str;
            }

            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                int found = 0;
                var convertMethod = typeof(SelectedGadgetPanel_Bind_Patch).GetMethod("Convert");

                foreach (var instruction in instructions)
                {
                    if (instruction.IsStloc() && ++found == 2)
                    {
                        yield return new CodeInstruction(OpCodes.Ldarg_3);
                        yield return new CodeInstruction(OpCodes.Call, convertMethod);
                    }

                    yield return instruction;
                }
            }
        }
    }
}