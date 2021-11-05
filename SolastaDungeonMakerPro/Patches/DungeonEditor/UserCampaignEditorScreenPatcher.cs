using HarmonyLib;
using TMPro;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class UserCampaignEditorScreenPatcher
    {
        // allows extra characters on campaign names
        [HarmonyPatch(typeof(UserCampaignEditorScreen), "RemoveUselessSpaces")]
        internal static class UserCampaignEditorScreen_RemoveUselessSpaces_Patch
        {
            public static bool Prefix(TMP_InputField textField)
            {
                if (!Main.Settings.AllowExtraKeyboardCharactersInNames)
                {
                    return true;
                }

                return Utils.RemoveInvalidFilenameChars.Invoke(textField);
            }
        }
    }
}