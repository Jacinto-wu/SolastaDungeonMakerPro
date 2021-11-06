using HarmonyLib;
using UnityEngine.UI;

namespace SolastaDungeonMakerPro.Patches
{
    internal static class MainMenuScreenPatcher
    {

        [HarmonyPatch(typeof(MainMenuScreen), "OnBeginShow")]
        internal static class _
        {
            internal static void Prefix(Toggle ___multiplayerToggle)
            {
                ___multiplayerToggle?.gameObject.SetActive(true);
            }
        }
    }
}