using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditorClipboard
{
    internal static class UserLocationEditorScreenPatcher
    {
        // adds the room to the board
        [HarmonyPatch(typeof(UserLocationEditorScreen), "SelectRoom")]
        internal static class UserLocationEditorScreen_SelectRoom_Patch
        {
            internal static bool Prefix(UserLocationEditorScreen __instance, UserRoom userRoom, bool moving)
            {
                if (!moving && Input.GetKey(KeyCode.LeftControl))
                {
                    Gui.GuiService.ShowMessage(
                        MessageModal.Severity.Attention2,
                        "DM Pro Mod", "Add this room to the Zappaboard?",
                        "Message/&MessageYesTitle", "Message/&MessageNoTitle",
                        () => Models.DungeonEditorClipboardContext.AddRoom(__instance, userRoom),
                        null);

                    return false;
                }

                return true;
            }
        }
    }
}