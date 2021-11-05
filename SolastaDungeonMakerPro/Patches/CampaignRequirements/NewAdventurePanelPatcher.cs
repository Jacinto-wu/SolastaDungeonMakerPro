using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.CampaignRequirements
{
    class NewAdventurePanelPatcher
    {
        // this patch changes the min/max requirements on campaigns
        [HarmonyPatch(typeof(NewAdventurePanel), "SelectCampaign")]
        internal static class NewAdventurePanel_SelectCampaign_Patch
        {
            internal static void Prefix(UserCampaign userCampaign)
            {
                if (userCampaign != null && Main.Settings.DungeonLevelBypass)
                {
                    userCampaign.StartLevelMin = Main.Settings.DungeonMinLevel;
                    userCampaign.StartLevelMax = Main.Settings.DungeonMaxLevel;
                }
            }
        }

        // this patch changes the min/max requirements on locations
        [HarmonyPatch(typeof(NewAdventurePanel), "SelectUserLocation")]
        internal static class NewAdventurePanel_SelectUserLocation_Patch
        {
            internal static void Prefix(UserLocation userLocation)
            {
                if (userLocation != null && Main.Settings.DungeonLevelBypass)
                {
                    userLocation.StartLevelMin = Main.Settings.DungeonMinLevel;
                    userLocation.StartLevelMax = Main.Settings.DungeonMaxLevel;
                }
            }
        }
    }
}