using AwesomeTechnologies.VegetationSystem;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonRenderer
{
    internal static class UnityTerrainPatcher
    {
        // hack until I learn how to properly disable vegetation masks
        [HarmonyPatch(typeof(UnityTerrain), "OnDisable")]
        internal static class UnityTerrain_OnDisable_Patch
        {
            internal static bool Prefix(UnityTerrain __instance)
            {
                return __instance?.Terrain?.terrainData != null;
            }
        }
    }
}