using System;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    // this patch scales down the party control panel whenever the party size is bigger than 4
    class PartyControlPanelPatcher
    {
        [HarmonyPatch(typeof(PartyControlPanel), "OnBeginShow")]
        internal static class PartyControlPanel_OnBeginShow_Patch
        {
            internal static void Prefix(RectTransform ___partyPlatesTable, RectTransform ___guestPlatesTable)
            {
                var party = ServiceRepository.GetService<IGameService>()?.Game?.GameCampaign?.Party?.CharactersList;

                if (party?.Count > Settings.GAME_PARTY_SIZE)
                {
                    var scale = (float)Math.Pow(Main.Settings.PartyControlPanelScale, party.Count - Settings.GAME_PARTY_SIZE);
                    ___partyPlatesTable.localScale = new Vector3(scale, scale, scale);
                    ___guestPlatesTable.localScale = new Vector3(scale, scale, scale);
                }
                else
                {
                    ___partyPlatesTable.localScale = new Vector3(1, 1, 1);
                    ___guestPlatesTable.localScale = new Vector3(1, 1, 1);
                }    
            }
        }
    }
}