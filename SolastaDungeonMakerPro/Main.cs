using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using ModKit;
using HarmonyLib;

namespace SolastaDungeonMakerPro
{
    public class Main
    {
        public static int LOAD_STATE = 0;
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry ModEntry;
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod;
        internal static MenuManager Menu;
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var harmony = new Harmony("SolastaDungeonMakerPro");
                var original = typeof(GameManager).GetMethod("BindPostDatabase");
                var postfix = typeof(Main).GetMethod("Init");

                ModEntry = modEntry;
                Logger = modEntry.Logger;
                Mod = new ModManager<Core, Settings>();
                Menu = new MenuManager();

                harmony.Patch(original, postfix: new HarmonyMethod(postfix));
                Menu.Enable(modEntry, Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        public static void Init()
        {
            LOAD_STATE = 1;

            if (Settings.DungeonMakerProEnabled)
            {
                LOAD_STATE = 2;

                Mod.Enable(ModEntry, Assembly.GetExecutingAssembly());

                Translations.Load(MOD_FOLDER);

                Models.DungeonEditorContext.UpdateAvailableDungeonSizes();

                Models.DungeonEditorContext.LoadFlatRooms();

                Models.DungeonEditorContext.UpdateCategories();

                Models.DungeonEditorContext.UpdateGadgetsPlacement();
                Models.DungeonEditorContext.UpdatePropsPlacement();

                Models.DungeonEditorContext.UnleashGadgetsOnAllEnvironments();
                Models.DungeonEditorContext.UnleashPropsOnAllEnvironments();
                Models.DungeonEditorContext.UnleashRoomsOnAllEnvironments();

                Models.DungeonEditorClipboardContext.Init();

                Models.EncountersSpawnContext.RegisterSpawnCommand();

                Models.ScriptingContext.AddLuaScriptGadget();

                Models.TelemaCampaignContext.Load();

                Models.MonsterContext.AddNewMonsters();
            }
        }
    }
}