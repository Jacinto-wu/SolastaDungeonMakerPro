using UnityModManagerNet;
using ModKit;

namespace SolastaDungeonMakerPro.Viewers
{
    public class SettingsViewer : IMenuSelectablePage
    {
        public string Name => "Settings";

        public int Priority => 1;

        public static string reqRestart = "[requires restart]".red().bold().italic();

        private static void DisplayCampaignsLocationsSettings()
        {
            bool toggle;
            int value;

            UI.Label("");
            UI.Label("Campaigns / Locations:".yellow());
            UI.Label("");

            toggle = Main.Settings.EnableTelemaCampaign;
            if (UI.Toggle("Enables Telema Kickstarter Demo", ref toggle))
            {
                Main.Settings.EnableTelemaCampaign = toggle;
                Models.TelemaCampaignContext.Switch(toggle);
            }

            toggle = Main.Settings.DungeonLevelBypass;
            if (UI.Toggle("Overrides required min/max level", ref toggle))
            {
                Main.Settings.DungeonLevelBypass = toggle;
            }
            
            if (Main.Settings.DungeonLevelBypass)
            {
                UI.Label("");
                value = Main.Settings.DungeonMinLevel;
                if (UI.Slider("Min level".white(), ref value,
                    Settings.DUNGEON_MIN_LEVEL, Settings.DUNGEON_MAX_LEVEL, Settings.DUNGEON_MIN_LEVEL, "", UI.AutoWidth()))
                {
                    Main.Settings.DungeonMinLevel = value;
                    if (Main.Settings.DungeonMinLevel > Main.Settings.DungeonMaxLevel)
                    {
                        Main.Settings.DungeonMaxLevel = Main.Settings.DungeonMinLevel;
                    }
                }

                value = Main.Settings.DungeonMaxLevel;
                if (UI.Slider("Max level".white(), ref value,
                    Settings.DUNGEON_MIN_LEVEL, Settings.DUNGEON_MAX_LEVEL, Settings.DUNGEON_MAX_LEVEL, "", UI.AutoWidth()))
                {
                    Main.Settings.DungeonMaxLevel = value;
                    if (Main.Settings.DungeonMaxLevel < Main.Settings.DungeonMinLevel)
                    {
                        Main.Settings.DungeonMinLevel = Main.Settings.DungeonMaxLevel;
                    }
                }
            }

            UI.Label("");
            value = Main.Settings.PartySize;
            if (UI.Slider("Overrides party size".white(), ref value, Settings.MIN_PARTY_SIZE, Settings.MAX_PARTY_SIZE, Settings.GAME_PARTY_SIZE, "", UI.AutoWidth()))
            {
                Main.Settings.PartySize = value;
            }
        }

        private static void DisplayDungeonMakerSettings()
        {
            int value;
            bool toggle;

            UI.Label("");
            UI.Label("Dungeon Maker:".yellow());
            UI.Label("");

            toggle = Main.Settings.AllowExtraKeyboardCharactersInNames;
            if (UI.Toggle("Allows extra keyboard characters in names", ref toggle))
            {
                Main.Settings.AllowExtraKeyboardCharactersInNames = toggle;
            }

            toggle = Main.Settings.FlexibleGadgetsPlacement;
            if (UI.Toggle("Allows gadgets to be placed anywhere on the map " + reqRestart, ref toggle))
            {
                Main.Settings.FlexibleGadgetsPlacement = toggle;
            }

            toggle = Main.Settings.FlexiblePropsPlacement;
            if (UI.Toggle("Allows props to be placed anywhere on the map " + reqRestart, ref toggle))
            {
                Main.Settings.FlexiblePropsPlacement = toggle;
            }

            toggle = Main.Settings.DebugLocations;
            if (UI.Toggle("Logs gadgets activation sequence", ref toggle))
            {
                Main.Settings.DebugLocations = toggle;
            }

            toggle = Main.Settings.UnleashAllNPCs;
            if (UI.Toggle("Unleashes monsters as NPCs", ref toggle))
            {
                Main.Settings.UnleashAllNPCs = toggle;
            }

            UI.Label("");
            value = Main.Settings.maxBackupFiles;
            if (UI.Slider("Max. backup files per location/campaign".white(), ref value, 0, 20, 10))
            {
                Main.Settings.maxBackupFiles = value;
            }

            UI.Label("");
            UI.Label("Dungeon Maker PRO:".yellow());
            UI.Label("");

            UI.Label("ATTENTION: use of any of these settings will require a player to install this mod".bold());
            UI.Label("");

            toggle = Main.Settings.EnableCustomDungeonSizes;
            if (UI.Toggle("Enables custom location sizes up to 500x500 " + reqRestart, ref toggle))
            {
                Main.Settings.EnableCustomDungeonSizes = toggle;
            }

            toggle = Main.Settings.EnableCustomMonsters;
            if (UI.Toggle("Enables custom monsters " + reqRestart, ref toggle))
            {
                Main.Settings.EnableCustomMonsters = toggle;
            }

            toggle = Main.Settings.EnableFlatRooms;
            if (UI.Toggle("Enables flat rooms " + reqRestart, ref toggle))
            {
                Main.Settings.EnableFlatRooms = toggle;
            }

            toggle = Main.Settings.EnableLuaScriptActivator;
            if (UI.Toggle("Enables the Lua scripting activator", ref toggle))
            {
                if (toggle != Main.Settings.EnableLuaScriptActivator)
                {
                    Models.ScriptingContext.SetLuaScriptActivatorHiddenStatus(!toggle);
                }
                Main.Settings.EnableLuaScriptActivator = toggle;
            }

            toggle = Main.Settings.UnleashAllVisualMoods;
            if (UI.Toggle("Unleashes visual moods " + reqRestart, ref toggle))
            {
                Main.Settings.UnleashAllVisualMoods = toggle;
            }

            toggle = Main.Settings.EnableModdedGadgets;
            if (UI.Toggle("Unlocks all gadgets", ref toggle))
            {
                if (toggle != Main.Settings.EnableModdedGadgets)
                {
                    Models.DungeonEditorContext.SetModdedGadgetsHiddenStatus(!toggle);
                }
                Main.Settings.EnableModdedGadgets = toggle;
            }

            toggle = Main.Settings.EnableModdedProps;
            if (UI.Toggle("Unlocks all props", ref toggle))
            {
                if (toggle != Main.Settings.EnableModdedProps)
                {
                    Models.DungeonEditorContext.SetModdedPropsHiddenStatus(!toggle);
                }
                Main.Settings.EnableModdedProps = toggle;
            }

            toggle = Main.Settings.EnableModdedRooms;
            if (UI.Toggle("Unlocks all rooms", ref toggle))
            {
                if (toggle != Main.Settings.EnableModdedRooms)
                {
                    Models.DungeonEditorContext.SetModdedRoomsHiddenStatus(!toggle);
                }
                Main.Settings.EnableModdedRooms = toggle;
            }
        }

        //private static void DisplayCheats()
        //{
        //    bool toggle;
        //    var characters = ServiceRepository.GetService<IGameService>()?.Game?.GameCampaign?.Party?.CharactersList;

        //    UI.Label("");
        //    UI.Label("Cheats:".yellow());
        //    UI.Label("");

        //    if (characters == null)
        //    {
        //        UI.Label("Enter a location first...", UI.AutoWidth());
        //    }
        //    else
        //    {
        //        toggle = Main.Settings.InvincibleParty;
        //        if (UI.Toggle("Invincible Party", ref toggle, 0, UI.AutoWidth()))
        //        {
        //            Main.Settings.InvincibleParty = toggle;
        //            Models.CheatsContext.SetPartyInvicible(toggle);
        //        }

        //        toggle = Main.Settings.IdleEnemies;
        //        if (UI.Toggle("Idle Enemies", ref toggle, 0, UI.AutoWidth()))
        //        {
        //            Main.Settings.IdleEnemies = toggle;
        //            Models.CheatsContext.SetMonstersIdle(toggle);
        //        }

        //        toggle = Main.Settings.NoFogOfWar;
        //        if (UI.Toggle("No Fog of War", ref toggle, 0, UI.AutoWidth()))
        //        {
        //            Main.Settings.NoFogOfWar = toggle;
        //            Models.CheatsContext.SetFogOfWar(toggle);
        //        }
        //    }
        //}

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.Label("Welcome to Dungeon Maker Pro".yellow().bold());
            UI.Div();

            if (!Main.Enabled) return;

            DisplayCampaignsLocationsSettings();
            DisplayDungeonMakerSettings();
            //DisplayCheats();
        }
    }
}