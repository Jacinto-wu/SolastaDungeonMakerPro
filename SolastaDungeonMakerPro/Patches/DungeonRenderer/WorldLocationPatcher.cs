using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonRenderer
{
    internal static class WorldLocationPatcher
    {
        // changes how the location / rooms are instantiated
        [HarmonyPatch(typeof(WorldLocation), "BuildFromUserLocation")]
        internal static class WorldLocation_BuildFromUserLocation_Patch
        {
            internal static void Postfix(WorldLocation __instance)
            {
                Models.DungeonRendererContext.FixFlatRoomReflectionProbe(__instance);
            }

            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                int found = 0;
                var setLocalPositionMethod = typeof(Transform).GetMethod("set_localPosition");
                var getTemplateVegetationMaskAreaMethod = typeof(Models.DungeonRendererContext).GetMethod("GetTemplateVegetationMaskArea");
                var setupLocationTerrainMethod = typeof(Models.DungeonRendererContext).GetMethod("SetupLocationTerrain");
                var setupFlatRoomsMethod = typeof(Models.DungeonRendererContext).GetMethod("SetupFlatRooms");
                var addVegetationMaskAreaMethod = typeof(Models.DungeonRendererContext).GetMethod("AddVegetationMaskArea");

                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Call, getTemplateVegetationMaskAreaMethod);

                yield return new CodeInstruction(OpCodes.Ldarg_0);
                yield return new CodeInstruction(OpCodes.Ldarg_1);
                yield return new CodeInstruction(OpCodes.Call, setupLocationTerrainMethod);

                foreach (var instruction in instructions)
                {
                    if (instruction.Calls(setLocalPositionMethod) && ++found == 1)
                    {
                        yield return new CodeInstruction(OpCodes.Ldloc_S, 4); // roomTransform
                        yield return new CodeInstruction(OpCodes.Ldloc_S, 2); // userRoom
                        yield return new CodeInstruction(OpCodes.Call, addVegetationMaskAreaMethod);

                        yield return instruction;

                        yield return new CodeInstruction(OpCodes.Ldloc_S, 4); // roomTransform
                        yield return new CodeInstruction(OpCodes.Ldloc_S, 2); // userRoom
                        yield return new CodeInstruction(OpCodes.Call, setupFlatRoomsMethod);
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