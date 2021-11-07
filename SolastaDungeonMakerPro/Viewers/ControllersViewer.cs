using UnityModManagerNet;
using ModKit;

namespace SolastaDungeonMakerPro.Viewers
{
    public class CombatSettingsViewer : IMenuSelectablePage
    {
        public string Name => "Controllers";

        public int Priority => 2;

        internal void DisplayControllerSettings()
        {
            bool toggle;
            var controllers = Models.HeroControllerContext.GetPlayersList().ToArray();
            var partyCharacters = Models.HeroControllerContext.GetCharactersList();

            UI.Label("");
            toggle = Main.Settings.EnableControllersOverride;
            if (UI.Toggle("Enables controllers override during combat", ref toggle))
            {
                Main.Settings.EnableControllersOverride = toggle;
            }

            if (Main.Settings.EnableControllersOverride)
            {
                UI.Label("");
                if (partyCharacters.Count == 0)
                {
                    UI.Label("Enter a location first...", UI.AutoWidth());
                }
                else if (!Models.HeroControllerContext.IsLocalPlayer())
                {
                    UI.Label("You can only change player controllers in a local session...", UI.AutoWidth());
                }
                else
                {
                    for (var index = 0; index < partyCharacters.Count; index++)
                    {
                        UI.HStack(partyCharacters[index].Name, 1, () =>
                        {
                            UI.SelectionGrid(ref Models.HeroControllerContext.CharacterPlayersChoices[index], controllers, controllers.Length, UI.AutoWidth());
                        });
                    }
                }
            }
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.Label("Welcome to Dungeon Maker Pro".yellow().bold());
            UI.Div();

            if (Main.Enabled)
            {
                DisplayControllerSettings();
            }
        }
    }
}