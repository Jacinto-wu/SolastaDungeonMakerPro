using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class GadgetBlueprintSelectionPanelPatcher
    {
        // better gadget sorting
        [HarmonyPatch(typeof(GadgetBlueprintSelectionPanel), "Compare")]
        internal static class GadgetBlueprintSelectionPanel_Compare_Patch
        {
            internal static bool Prefix(GadgetBlueprint left, GadgetBlueprint right, ref int __result)
            {
                var element1 = DatabaseRepository.GetDatabase<BlueprintCategory>().GetElement(left.Category);
                var element2 = DatabaseRepository.GetDatabase<BlueprintCategory>().GetElement(right.Category);

                var title1 = Gui.Format(element1.GuiPresentation.Title);
                var title2 = Gui.Format(element2.GuiPresentation.Title);

                __result = title1.CompareTo(title2);

                return __result == 0;
            }
        }
    }
}