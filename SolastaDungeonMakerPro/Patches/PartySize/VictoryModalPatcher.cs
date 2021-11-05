using System;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    // this patch scales down the victory modal whenever the party size is bigger than 4
    class VictoryModalPatcher
    {
        [HarmonyPatch(typeof(VictoryModal), "OnBeginShow")]
        internal static class VictoryModal_OnBeginShow_Patch
        {
            internal static void Prefix(RectTransform ___heroStatsGroup)
            {
                var party = ServiceRepository.GetService<IGameService>()?.Game?.GameCampaign?.Party?.CharactersList;

                if (party?.Count > Settings.GAME_PARTY_SIZE)
                {
                    var scale = (float)Math.Pow(Main.Settings.VictoryModalScale, party.Count - Settings.GAME_PARTY_SIZE);
                    ___heroStatsGroup.localScale = new Vector3(scale, 1, scale);
                }
                else
                {
                    ___heroStatsGroup.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}