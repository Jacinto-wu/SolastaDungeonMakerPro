using System;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    // this patch scales down the rest sub panel whenever the party size is bigger than 4
    class RestSubPanelPatcher
    {
        [HarmonyPatch(typeof(RestSubPanel), "OnBeginShow")]
        internal static class RestSubPanel_OnBeginShow_Patch
        {
            internal static void Prefix(RectTransform ___characterPlatesTable, RectTransform ___restModulesTable)
            {
                var party = ServiceRepository.GetService<IGameService>()?.Game?.GameCampaign?.Party?.CharactersList;

                if (party?.Count > Settings.GAME_PARTY_SIZE)
                {
                    var scale = (float)Math.Pow(Main.Settings.RestPanelScale, party.Count - Settings.GAME_PARTY_SIZE);
                    ___restModulesTable.localScale = new Vector3(scale, scale, scale);
                    ___characterPlatesTable.localScale = new Vector3(scale, scale, scale);
                } 
                else
                {
                    ___restModulesTable.localScale = new Vector3(1, 1, 1);
                    ___characterPlatesTable.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}