using HarmonyLib;
using TA;

namespace SolastaDungeonMakerPro.Patches.PartySize
{
    class GameLocationCharacterManagerPatch
    {
        // use this patch to recalculate the additional party members positions
        [HarmonyPatch(typeof(GameLocationCharacterManager), "UnlockCharactersForLoading")]
        internal static class GameLocationCharacterManager_UnlockCharactersForLoading_Patch
        {
            internal static void Prefix(GameLocationCharacterManager __instance)
            {
                var partyCharacters = __instance?.PartyCharacters;

                for (var idx = Settings.GAME_PARTY_SIZE; idx < partyCharacters.Count; idx++)
                {
                    var position = partyCharacters[idx % Settings.GAME_PARTY_SIZE].LocationPosition;
                    partyCharacters[idx].LocationPosition = new int3(position.x, position.y, position.z);
                }           
            }
        }
    }
}