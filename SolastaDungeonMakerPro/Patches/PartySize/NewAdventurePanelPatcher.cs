using HarmonyLib;
using SolastaModApi;
using UnityEngine;
using SolastaModApi.Extensions;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    class NewAdventurePanelPatcher
    {
        // this patch tweaks the UI to allow less/more heroes to be selected on a campaign
        [HarmonyPatch(typeof(NewAdventurePanel), "OnBeginShow")]
        internal static class NewAdventurePanel_OnBeginShow_Patch
        {
            internal static void Prefix(NewAdventurePanel __instance, RectTransform ___characterSessionPlatesTable)
            {
                // overrides campaign party size
                DatabaseHelper.CampaignDefinitions.UserCampaign.SetPartySize<CampaignDefinition>(Main.Settings.PartySize);

                // adds new character plates if required
                for (var i = Settings.GAME_PARTY_SIZE; i < Main.Settings.PartySize; i++)
                {
                    var firstChild = ___characterSessionPlatesTable.GetChild(0);

                    Object.Instantiate(firstChild, firstChild.parent);
                }

                // scales down the plates table if required
                if (Main.Settings.PartySize > Settings.GAME_PARTY_SIZE)
                {
                    var scale = (float)System.Math.Pow(Main.Settings.AdventurePanelScale, Main.Settings.PartySize - Settings.GAME_PARTY_SIZE);
                    ___characterSessionPlatesTable.localScale = new Vector3(scale, scale, scale);
                }
                else
                {
                    ___characterSessionPlatesTable.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}