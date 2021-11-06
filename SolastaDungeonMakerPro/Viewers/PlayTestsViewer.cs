using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.CampaignDefinitions;

namespace SolastaDungeonMakerPro.Viewers
{
    public class PlayTestsViewer : IMenuSelectablePage
    {
        public string Name => "Playtests";

        public int Priority => 4;

        private static bool showAttributes = false;
        private static readonly List<CharacterTemplateDefinition> Templates = new List<CharacterTemplateDefinition>();
        private static readonly List<CharacterTemplateDefinition> DefaultParty = new List<CharacterTemplateDefinition>();
        private static readonly List<CharacterTemplateDefinition> Party = new List<CharacterTemplateDefinition>();

        private static List<CharacterTemplateDefinition> GetCharacterTemplates()
        {
            if (Templates.Count == 0)
            {
                var characterTemplateDefinitionDB = DatabaseRepository.GetDatabase<CharacterTemplateDefinition>();

                foreach (var templateDefinition in characterTemplateDefinitionDB.GetAllElements())
                {
                    Templates.Add(templateDefinition);

                    if (templateDefinition.Name == "Level1_Cleric_Celia_Esbery" || templateDefinition.Name == "Level1_Paladin_Berden_Redstone" || 
                        templateDefinition.Name == "Level1_Rogue_Anton_Whitesail" || templateDefinition.Name == "Level1_Wizard_Nialla_Wildwind")
                    {
                        DefaultParty.Add(templateDefinition);
                    }
                }

                Templates.Sort((a, b) =>
                {
                    var result = a.CharacterLevel - b.CharacterLevel;

                    if (result == 0)
                    {
                        result = a.FirstName.CompareTo(b.FirstName);

                        if (result == 0)
                        {
                            result = a.SurName.CompareTo(b.SurName);
                        }
                    }

                    return result;
                });
            }

            return Templates;
        }

        private static void RebindParty()
        {
            var characterPoolService = ServiceRepository.GetService<ICharacterPoolService>();

            UserCampaignPlayTest.PredefinedParty.Clear();

            for (var i = 0; i < 4; i++)
            {
                if (i < Party.Count)
                {
                    if (!characterPoolService.ContainsCharacter(Party[i].Name))
                    {
                        Party[i].SetEditorOnly(false);
                        characterPoolService.CreateCharacterFromTemplate(Party[i], true);
                    }
                    UserCampaignPlayTest.PredefinedParty.Add(Party[i].Name);
                }
                else
                {
                    UserCampaignPlayTest.PredefinedParty.Add(DefaultParty[i - Party.Count].Name);
                }
            }
        }

        private static void DisplayTemplateStats(CharacterTemplateDefinition template)
        {
            if (template.FirstName.Contains("&")) 
                return;

            using (UI.HorizontalScope())
            {
                UI.ActionButton("-".bold().red(), () => { if (Party.Contains(template)) { Party.Remove(template); RebindParty(); } }, UI.Width(30));
                UI.ActionButton("+".bold().red(), () => { if (Party.Count < 4 && !Party.Contains(template)) Party.Add(template); RebindParty(); }, UI.Width(30));

                var displayName = $"{template.FirstName} {template.SurName}";

                if (Party.Contains(template))
                {
                    UI.Label(displayName.orange().bold(), UI.Width(240));
                }
                else
                {
                    UI.Label(displayName.bold(), UI.Width(240));
                }

                UI.Label(template.MainRace.FormatTitle().white(), UI.Width(100));
                UI.Label(template.MainClass.FormatTitle().white() + " / " + template.CharacterLevel.ToString("00").yellow().bold(), UI.Width(100));

                var attributesLabel = showAttributes ? "" : "Atributes";
                UI.DisclosureToggle(attributesLabel, ref showAttributes, attributesLabel.Length * 12);

                if (showAttributes)
                {
                    UI.Label($"Str: {template.AbilityScores[0]:0#}".white(), UI.Width(48));
                    UI.Label($"Con: {template.AbilityScores[1]:0#}".yellow(), UI.Width(48));
                    UI.Label($"Dex: {template.AbilityScores[2]:0#}".white(), UI.Width(48));
                    UI.Label($"Int: {template.AbilityScores[3]:0#}".yellow(), UI.Width(48));
                    UI.Label($"Wis: {template.AbilityScores[4]:0#}".white(), UI.Width(48));
                    UI.Label($"Cha: {template.AbilityScores[5]:0#}".yellow(), UI.Width(48));
                };
            }
        }

        private static void DisplayNPCs()
        {
            using (UI.VerticalScope(UI.AutoWidth(), UI.AutoHeight()))
            {
                UI.Label("");
                UI.Label($"Press +/- to add/remove a hero to/from the Playtest party ".bold() + "[useful to test higher level dungeons]".yellow().bold());

                UI.Label("");
                foreach (var template in GetCharacterTemplates())
                {
                    DisplayTemplateStats(template);
                }
            }
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.Label("Welcome to Dungeon Maker Pro".yellow().bold());
            UI.Div();

            switch (Main.LOAD_STATE)
            {
                case 1:
                    UI.Label("");
                    UI.Label("Mod is currently disabled. " + "SolastaModHelpers".orange().bold() + " was detected.");
                    break;

                case 2:
                    DisplayNPCs();
                    break;
            }
        }
    }
}