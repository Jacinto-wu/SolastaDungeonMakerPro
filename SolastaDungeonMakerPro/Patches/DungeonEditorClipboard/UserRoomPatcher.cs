using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditorClipboard
{
    internal static class UserRoomPatcher
    {
        // reverts the blueprint back to the original before pasting on the map
        [HarmonyPatch(typeof(UserRoom), "Clone")]
        internal static class UserRoom_Clone_Patch
        {
            internal static void Prefix(UserRoom __instance)
            {
                var roomBlueprintName = __instance.RoomBlueprint.name;
                var clipboardIndex = roomBlueprintName.IndexOf("Zappaboard");

                if (clipboardIndex >= 0)
                {
                    var originalRoomName = roomBlueprintName.Substring(0, clipboardIndex);
                    var originalRoomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>().GetElement(originalRoomName);

                    __instance.RoomBlueprint = originalRoomBlueprint;
                }
            }
        }
    }
}