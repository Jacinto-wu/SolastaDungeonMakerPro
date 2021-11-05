using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using SolastaModApi.Extensions;
using ModKit;
using static SolastaModApi.DatabaseHelper.GadgetBlueprints;

namespace SolastaDungeonMakerPro.Models
{
    public class ScriptingContext
    {
        internal const string ACTIVATOR_SCRIPT_NAME = "LuaScript";

        private const string ACTIVATOR_SCRIPT_PARAMETER_NAME = "Script";

        private static readonly Script LuaScripting = new Script();

        private static string BuildUserLocationScriptFilename(string title) =>
            Path.Combine(TacticalAdventuresApplication.UserLocationsDirectory, IOHelper.GetOsCompliantFilename(title)) + ".lua";

        private static string BuildUserCampaignScriptFilename(string title) =>
            Path.Combine(TacticalAdventuresApplication.UserCampaignsDirectory, IOHelper.GetOsCompliantFilename(title)) + ".lua";

        internal static void SetLuaScriptActivatorHiddenStatus(bool hidden)
        {
            DatabaseRepository.GetDatabase<GadgetBlueprint>().GetElement(ACTIVATOR_SCRIPT_NAME).GuiPresentation.SetHidden(hidden);
        }

        internal static void AddLuaScriptGadget()
        {
            var dbGadgetBlueprint = DatabaseRepository.GetDatabase<GadgetBlueprint>();
            var LuaScripting = UnityEngine.Object.Instantiate(ActivatorEntry);
            var parameterScript = new GadgetParameterDescription();

            parameterScript.SetName(ACTIVATOR_SCRIPT_PARAMETER_NAME);
            parameterScript.SetType(GadgetBlueprintDefinitions.Type.Speech);
            parameterScript.SetRequiresNonEmpty(false);

            LuaScripting.name = ACTIVATOR_SCRIPT_NAME;
            LuaScripting.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), LuaScripting.name).ToString());
            LuaScripting.GuiPresentation.Title = "Lua Script".red();
            LuaScripting.Parameters.Clear();
            LuaScripting.Parameters.Add(parameterScript);

            dbGadgetBlueprint.Add(LuaScripting);

            SetLuaScriptActivatorHiddenStatus(!Main.Settings.EnableLuaScriptActivator);
        }

        internal static void LoadLuaScript(UserLocation userLocation, bool isUserCampaign)
        {
            var script = string.Empty;
            var scriptsDirectory = Path.Combine(Main.MOD_FOLDER, "Scripts");
            var scriptCampaignFilename = BuildUserCampaignScriptFilename(userLocation.Title);
            var scriptLocationFilename = BuildUserLocationScriptFilename(userLocation.Title);

            // loads scripts directory
            if (!Directory.Exists(scriptsDirectory))
            {
                Directory.CreateDirectory(scriptsDirectory);
            }
            else
            {
                var scriptFiles = Directory.EnumerateFiles(scriptsDirectory, "*.lua").ToList();

                scriptFiles.Sort();

                for (var i = 0; i < scriptFiles.Count; i++)
                {
                    script += "\n" + File.ReadAllText(scriptFiles[i], System.Text.Encoding.UTF8);
                }
            }

            if (isUserCampaign && File.Exists(scriptCampaignFilename))
            {
                script += "\n" + File.ReadAllText(scriptCampaignFilename, System.Text.Encoding.UTF8);
            }
            else if (!isUserCampaign && File.Exists(scriptLocationFilename))
            {
                script += "\n" + File.ReadAllText(scriptLocationFilename, System.Text.Encoding.UTF8);
            }
            else
            {
                foreach (var userRoom in userLocation.UserRooms)
                {
                    foreach (var userGadget in userRoom.UserGadgets)
                    {
                        if (userGadget.UniqueName.StartsWith(ACTIVATOR_SCRIPT_NAME))
                        {
                            script += "\n" + userGadget.ParameterValues.Find(x => x.GadgetParameterDescription.Name == ACTIVATOR_SCRIPT_PARAMETER_NAME).StringValue.Trim();
                            goto PARSE_PHASE;
                        }
                    }
                }
            }

        PARSE_PHASE:
            if (script != string.Empty)
            {
                try
                {
                    UserData.RegistrationPolicy = InteropRegistrationPolicy.Automatic;   
                    LuaScripting.Globals["Utils"] = new Models.Scripting.Utils();
                    LuaScripting.Globals["Helpers"] = new SolastaModApi.DatabaseHelper();
                    LuaScripting.DoString(script);
                }
                catch (Exception ex)
                {
                    Main.Warning("Lua Scripting parsing error: " + ex.ToString());
                }
            }
        }

        internal bool FunctorCanExecute;

        internal IEnumerator RunLuaEvent(string eventName, object param, List<GameLocationCharacter> selectedCharacters)
        {
            FunctorCanExecute = true;

            if (LuaScripting.Globals.Keys.Any(x => x.String == eventName))
            {
                yield return null;

                var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
                var actors = new List<Scripting.Actor>();
                var party = new List<Scripting.Actor>();

                // prepare Lua globals
                if (selectedCharacters != null)
                {
                    foreach (var gameLocationCharacter in selectedCharacters)
                    {
                        actors.Add(new Models.Scripting.Actor(gameLocationCharacter));
                    }
                }

                if (gameLocationCharacterService?.PartyCharacters?.Count > 0)
                {
                    foreach (var gameLocationCharacter in gameLocationCharacterService.PartyCharacters)
                    {
                        party.Add(new Models.Scripting.Actor(gameLocationCharacter));
                    }
                }

                if (gameLocationCharacterService?.GuestCharacters?.Count > 0)
                {
                    foreach (var gameLocationCharacter in gameLocationCharacterService.GuestCharacters)
                    {
                        party.Add(new Models.Scripting.Actor(gameLocationCharacter));
                    }
                }

                LuaScripting.Globals["actors"] = actors;
                LuaScripting.Globals["party"] = party;

                yield return null;

                DynValue coroutine = null;

                // prepare coroutine
                try
                {
                    var function = LuaScripting.Globals[eventName];

                    coroutine = LuaScripting.CreateCoroutine(function);
                    coroutine.Coroutine.AutoYieldCounter = 1000;
                }
                catch (Exception ex)
                {
                    Main.Warning("Lua Scripting coroutine error " + eventName + ": " + ex.ToString());
                }

                if (coroutine != null)
                {
                    yield return null;

                    string name;
                    DynValue result = null;

                    // run coroutine first leg
                    try
                    {
                        switch (param)
                        {
                            case FunctorParametersDescription functorParameters:
                                name = functorParameters.SourceGadget.UserGadget != null ? functorParameters.SourceGadget.UserGadget.UniqueName : string.Empty;
                                result = coroutine.Coroutine.Resume(name, functorParameters);
                                break;

                            case GameLocationBattle gameLocationBattle:
                                name = gameLocationBattle.ActiveContender != null ? gameLocationBattle.ActiveContender.Name : string.Empty;
                                result = coroutine.Coroutine.Resume(name, gameLocationBattle);
                                break;
                        }
                    }
                    catch (ScriptRuntimeException ex)
                    {
                        Main.Warning("Lua Scripting execution error " + eventName + ": " + ex.ToString());
                    }

                    // run couroutine remaining legs
                    while (result?.Type == DataType.Nil)
                    {
                        yield return null;
                        result = coroutine.Coroutine.Resume();
                    }

                    switch (result?.Type)
                    {
                        case DataType.Boolean:
                            FunctorCanExecute = result.Boolean;
                            break;

                        case DataType.Number:
                            FunctorCanExecute = result.Number > 0;
                            break;
                           
                        case DataType.Tuple:
                            FunctorCanExecute = result.Tuple[0].Boolean;
                            break;

                        default:
                            FunctorCanExecute = true;
                            break;
                    }
                }
            }
            
            yield break;
        }
    }
}