using HarmonyLib;
using ModKit;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{
    internal static class UserLocationSettingsModalPatcher
    {
        // unlocks visual moods across all environments
        [HarmonyPatch(typeof(UserLocationSettingsModal), "RefreshVisualMoods")]
        internal static class UserLocationSettingsModal_RefreshVisualMoods_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                int found = 0;

                foreach (var instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Brfalse_S && ++found == 1 && Main.Settings.UnleashAllVisualMoods)
                    {
                        yield return new CodeInstruction(OpCodes.Pop);
                    }
                    else
                    {
                        yield return instruction;
                    }
                }
            }  
        }

        // adds custom dungeon sizes to the drop down
        [HarmonyPatch(typeof(UserLocationSettingsModal), "RuntimeLoaded")]
        internal static class UserLocationSettingsModal_RuntimeLoaded_Patch
        {
            internal static void Postfix(UserLocationSettingsModal __instance, List<TMP_Dropdown.OptionData> ___optionsListSize)
            {
                if (Main.Settings.EnableCustomDungeonSizes)
                {
                    for (UserLocationDefinitions.Size size = (UserLocationDefinitions.Size)Models.DungeonEditorContext.ExtendedDungeonSize.First; size <= (UserLocationDefinitions.Size)Models.DungeonEditorContext.ExtendedDungeonSize.Last; size++)
                    {
                        GuiDropdown.OptionDataAdvanced optionDataAdvanced = new GuiDropdown.OptionDataAdvanced
                        {
                            text = Gui.FormatLocationSize(size).yellow() + " " + Gui.Format("{0} x {1}", UserLocationDefinitions.CellsBySize[size].ToString(), UserLocationDefinitions.CellsBySize[size].ToString()),
                            TooltipContent = string.Empty
                        };
                        ___optionsListSize.Add((TMP_Dropdown.OptionData)optionDataAdvanced);
                    }
                }
            }
        }

        // allows extra characters on location names
        [HarmonyPatch(typeof(UserLocationSettingsModal), "RemoveUselessSpaces")]
        internal static class UserLocationSettingsModal_RemoveUselessSpaces_Patch
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