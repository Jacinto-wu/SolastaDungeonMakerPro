using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class ListElementButtonPatcher
    {
        // better tooltips
        [HarmonyPatch(typeof(ListElementButton), "BindItem")]
        internal static class ListElementButton_BindItem_Patch
        {
            internal static void Postfix(GuiLabel ___nameLabel)
            {
                var guiTooltip = ___nameLabel.gameObject.AddComponent<GuiTooltip>();

                guiTooltip.Content = Gui.Format("Caption/&GadgetParametersRemoveDescription") + ":\n" + ___nameLabel.Text;
            }
        }
    }
}