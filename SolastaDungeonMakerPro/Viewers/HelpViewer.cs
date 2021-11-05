using UnityModManagerNet;
using ModKit;
using System.Collections.Generic;

namespace SolastaDungeonMakerPro.Viewers
{
    public class HelpViewer : IMenuSelectablePage
    {
        public string Name => "Help & Credits";

        public int Priority => 10;

        private static Dictionary<string, string> creditsTable = new Dictionary<string, string>
        {
            { "DubhHerder", "custom monsters" }
        };

        private static void DisplayHelp()
        {
            UI.Label("");
            UI.Label("Dungeon Maker features:".yellow());
            UI.Label("");
            UI.Label(". Unleashes props and gadgets from all environments");
            UI.Label(". Mixes and matches rooms from all environments");
            UI.Label(". Adds bigger map sizes up to 500x500");
            UI.Label(". Adds flat rooms up to 96x96 in size");
            UI.Label(". Adds custom monsters");
            UI.Label(". LUA Scripting " +  "[check both the Scripts and Samples folder for more details]".red().bold().italic());

            UI.Label("");
            UI.Label("Dungeon features:".yellow());
            UI.Label("");
            UI.Label("  . Plays the game with a smaller party size");
            UI.Label("  . Spawns new encounters on demand");
            UI.Label("  . Enables enemies to be controlled by a human");

            UI.Label("");
            UI.Label("Credits:".yellow());
            UI.Label("");

            foreach (var kvp in creditsTable)
            {
                using (UI.HorizontalScope())
                {
                    UI.Label(kvp.Key.orange(), UI.Width(100));
                    UI.Label(kvp.Value, UI.Width(400));
                }
            }
            UI.Label("");
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.Label("Welcome to Dungeon Maker Pro".yellow().bold());
            UI.Div();

            DisplayHelp();
        }
    }
}