using UnityEngine;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.CampaignDefinitions;
using static SolastaModApi.DatabaseHelper.CharacterTemplateDefinitions;

namespace SolastaDungeonMakerPro.Models
{
    internal static class TelemaCampaignContext
    {
        internal static void Switch(bool enabled)
        {
            TelemaDemo.GuiPresentation.SetHidden(!enabled);
            DatabaseRepository.GetDatabase<CampaignDefinition>().GetElement("TelemaDemoUnleashed").GuiPresentation.SetHidden(!enabled);
        }

        internal static void Load()
        {
            TelemaDemo.SetEditorOnly(false);

            Garrad.SetEditorOnly(false);
            Rhuad.SetEditorOnly(false);
            Vigdis.SetEditorOnly(false);
            Violet.SetEditorOnly(false);

            var TelemaDemoUnleashed = Object.Instantiate(TelemaDemo);

            TelemaDemoUnleashed.name = "TelemaDemoUnleashed";
            TelemaDemoUnleashed.SetGuid("397df3dcfcd444f09df11d05034ec52e");
            TelemaDemoUnleashed.GuiPresentation.Title += " Unleashed";
            TelemaDemoUnleashed.PredefinedParty.Clear();

            DatabaseRepository.GetDatabase<CampaignDefinition>().Add(TelemaDemoUnleashed);

            Switch(Main.Settings.EnableTelemaCampaign);
        }
    }   
}
