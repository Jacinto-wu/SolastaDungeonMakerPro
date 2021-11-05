using System;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    // this patch scales down the revive party control panel whenever the party size is bigger than 4
    class RevivePartyControlPanelPatcher
    {
        [HarmonyPatch(typeof(RevivePartyControlPanel), "OnBeginShow")]
        internal static class RevivePartyControlPanel_OnBeginShow_Patch
        {
            internal static void Prefix(RectTransform ___partyPlatesTable)
            {
                var party = ServiceRepository.GetService<IGameService>()?.Game?.GameCampaign?.Party?.CharactersList;

                if (party?.Count > Settings.GAME_PARTY_SIZE)
                {
                    var scale = (float)Math.Pow(Main.Settings.RevivePartyControlPanelScale, party.Count - Settings.GAME_PARTY_SIZE);
                    ___partyPlatesTable.localScale = new Vector3(scale, 1, scale);
                }
                else
                {
                    ___partyPlatesTable.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}