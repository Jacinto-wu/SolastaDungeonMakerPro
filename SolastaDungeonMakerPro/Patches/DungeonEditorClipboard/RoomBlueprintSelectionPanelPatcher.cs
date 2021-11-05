using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditorClipboard
{
    internal static class RoomBlueprintSelectionPanelPatcher
    {
        // removes the room from the board
        [HarmonyPatch(typeof(RoomBlueprintSelectionPanel), "BlueprintItemSelected")]
        internal static class RoomBlueprintSelectionPanel_BlueprintItemSelected_Patch
        {
            internal static bool Prefix(BaseBlueprintItem blueprintItem)
            {
                if (Input.GetKey(KeyCode.LeftControl) && blueprintItem is RoomBlueprintItem roomBlueprintItem && roomBlueprintItem.RoomBlueprint.Category == "Zappaboard")
                {
                    var userLocationEditorScreen = roomBlueprintItem.GetComponentInParent<UserLocationEditorScreen>();

                    Gui.GuiService.ShowMessage(
                        MessageModal.Severity.Attention2,
                        "DM Pro Mod", "Remove this room from the Zappaboard?",
                        "Message/&MessageYesTitle", "Message/&MessageNoTitle",
                        () => Models.DungeonEditorClipboardContext.RemoveRoom(userLocationEditorScreen, roomBlueprintItem.RoomBlueprint),
                        null);

                    return false;
                }

                return true;
            }
        }

        // adds the rooms in the board to the panel
        [HarmonyPatch(typeof(RoomBlueprintSelectionPanel), "Bind")]
        internal static class RoomBlueprintSelectionPanel_Bind_Patch
        {
            internal static void Prefix(RoomBlueprintSelectionPanel __instance, ref RoomBlueprint[] ___allBlueprints)
            {
                var roomBlueprints = DatabaseRepository.GetDatabase<RoomBlueprint>().GetAllElements();
                int size = roomBlueprints.Length + Models.DungeonEditorClipboardContext.MyRoomBlueprints.Count;

                ___allBlueprints = new RoomBlueprint[size];

                for (var i = 0; i < roomBlueprints.Length; i++)
                {
                    ___allBlueprints[i] = roomBlueprints[i];
                }

                for (var i = 0; i < Models.DungeonEditorClipboardContext.MyRoomBlueprints.Count; i++)
                {
                    var myRoomBlueprint = Models.DungeonEditorClipboardContext.MyRoomBlueprints[i];

                    ___allBlueprints[i + roomBlueprints.Length] = myRoomBlueprint;
                }

                System.Array.Sort<RoomBlueprint>(___allBlueprints, (IComparer<RoomBlueprint>)__instance);
            }
        }

    }
}