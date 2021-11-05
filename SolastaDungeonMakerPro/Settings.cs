using System;
using System.Collections.Generic;
using System.Reflection;
using UnityModManagerNet;

namespace SolastaDungeonMakerPro
{
    internal class Core
    {

    }
    
    public class Settings : UnityModManager.ModSettings
    {
        internal static Assembly GetModAssembly(string modName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.FullName.Contains(modName))
                {
                    return assembly;
                }
            }

            return null;
        }

        internal static bool SolastaDungeonMakerProEnabled
        {
            get => GetModAssembly("SolastaModHelpers") == null;
        }

        internal const string GUID = "bff53ba4bb694bf5a69b3ae280eec118";

        public const int GAME_PARTY_SIZE = 4;
        public const int DUNGEON_MIN_LEVEL = 1;
        public const int DUNGEON_MAX_LEVEL = 20;
        public const int MIN_PARTY_SIZE = 1;
        public const int MAX_PARTY_SIZE = 6;
        public const int MAX_ENCOUNTER_CHARACTERS = 16;
        public const int DM_CONTROLLER_ID = 4242;

        public const float ADVENTURE_PANEL_DEFAULT_SCALE = 0.75f;
        public const float REST_PANEL_DEFAULT_SCALE = 0.8f;
        public const float PARTY_CONTROL_PANEL_DEFAULT_SCALE = 0.95f;
        public const float VICTORY_MODAL_DEFAULT_SCALE = 0.85f;
        public const float REVIVE_PARTY_CONTROL_PANEL_DEFAULT_SCALE = 0.85f;

        public const InputCommands.Id CTRL_SHIFT_E = (InputCommands.Id)22220000;

        public List<Models.DungeonEditorClipboardContext.MyRoom> MyRooms = new List<Models.DungeonEditorClipboardContext.MyRoom>();

        public bool EnableTelemaCampaign = false;
        public bool DungeonLevelBypass = false;
        public int DungeonMinLevel = DUNGEON_MIN_LEVEL;
        public int DungeonMaxLevel = DUNGEON_MAX_LEVEL;
        public int PartySize = GAME_PARTY_SIZE;

        public bool AllowExtraKeyboardCharactersInNames = false;
        public bool FlexibleGadgetsPlacement = false;
        public bool FlexiblePropsPlacement = false;
        public bool DebugLocations = false;
        public bool UnleashAllNPCs = false;
        public int maxBackupFiles = 10;

        //public bool EnableDungeonRotation = true;

        public bool EnableCustomDungeonSizes = false;
        public bool EnableCustomMonsters = false;
        public bool EnableFlatRooms = false;
        public bool EnableModdedRooms = false;
        public bool EnableModdedGadgets = false;
        public bool EnableModdedProps = false;
        public bool UnleashAllVisualMoods = false;
        public bool EnableLuaScriptActivator = false;

        public bool EnableControllersOverride = false;

        public bool InvincibleParty = false;
        public bool IdleEnemies = false;
        public bool NoFogOfWar = false;

        //public bool GameMasterMode = false;

        public float AdventurePanelScale = ADVENTURE_PANEL_DEFAULT_SCALE;
        public float RestPanelScale = REST_PANEL_DEFAULT_SCALE;
        public float PartyControlPanelScale = PARTY_CONTROL_PANEL_DEFAULT_SCALE;
        public float VictoryModalScale = VICTORY_MODAL_DEFAULT_SCALE;
        public float RevivePartyControlPanelScale = REVIVE_PARTY_CONTROL_PANEL_DEFAULT_SCALE;
    }
}