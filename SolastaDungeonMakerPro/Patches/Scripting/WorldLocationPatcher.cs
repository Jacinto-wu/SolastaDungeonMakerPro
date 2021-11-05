using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.Scripting
{
    internal static class WorldLocationPatcher
    {
        [HarmonyPatch(typeof(WorldLocation), "BuildFromUserLocation")]
        internal static class WorldLocation_BuildFromUserLocation_Patch
        {
            internal static void Postfix(UserLocation userLocation, UserCampaign userCampaign)
            {
                Models.ScriptingContext.LoadLuaScript(userLocation, userCampaign != null);
            }
        }
    }
}