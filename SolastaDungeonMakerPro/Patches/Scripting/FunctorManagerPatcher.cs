using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SolastaDungeonMakerPro.Patches.Scripting
{
    public class FunctorTrap : Functor
    {
        private readonly string eventName;
        private readonly Functor functor;

        public FunctorTrap(string eventName, Functor functor)
        {
            this.eventName = "on_" + ToUnderscoreCase(eventName);
            this.functor = functor;
        }

        public override IEnumerator Execute(FunctorParametersDescription functorParameters, Functor.FunctorExecutionContext context)
        {
            var scriptingContext = new Models.ScriptingContext();
            var isUserGadget = functorParameters.SourceGadget?.IsUserGadget == true;

            if (isUserGadget)
            {
                var selectedCharacters = new List<GameLocationCharacter>();
                
                this.SelectCharacters(functorParameters, selectedCharacters);

                if (Main.Settings.DebugLocations)
                {
                    Main.Warning($"LUA: {eventName} {functorParameters.SourceGadget.UserGadget.UniqueName} - actors: {selectedCharacters.Count}");
                }

                yield return scriptingContext.RunLuaEvent(eventName, functorParameters, selectedCharacters);
            }

            if (!isUserGadget || scriptingContext.FunctorCanExecute)
            {
                yield return functor.Execute(functorParameters, context);
            }

            yield break;
        }

        public static string ToUnderscoreCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }

    public class MyFunctorUserGadgetOperation : Functor
    {
        public override IEnumerator Execute(FunctorParametersDescription functorParameters, Functor.FunctorExecutionContext context)
        {
            var scriptingContext = new Models.ScriptingContext();

            if (functorParameters.SourceGadget.UserGadget.GadgetBlueprint.Name != Models.ScriptingContext.ACTIVATOR_SCRIPT_NAME)
            {
                var selectedCharacters = new List<GameLocationCharacter>();

                this.SelectCharacters(functorParameters, selectedCharacters);

                switch (functorParameters.IntParameter)
                {
                    case 0:
                        yield return scriptingContext.RunLuaEvent("on_activate", functorParameters, selectedCharacters);
                        break;

                    case 1:
                        yield return scriptingContext.RunLuaEvent("on_deactivate", functorParameters, selectedCharacters);
                        break;

                    case 2:
                        yield return scriptingContext.RunLuaEvent("on_enable", functorParameters, selectedCharacters);
                        break;

                    case 3:
                        yield return scriptingContext.RunLuaEvent("on_disable", functorParameters, selectedCharacters);
                        break;
                }
            }

            if (scriptingContext.FunctorCanExecute)
            {
                yield return new FunctorUserGadgetOperation().Execute(functorParameters, context);
            }

            yield break;
        }
    }

    internal static class FunctorManagerPatcher
    {
        [HarmonyPatch(typeof(FunctorManager), "RegisterFunctor")]
        internal static class FunctorManager_RegisterFunctor_Patch
        {
            internal static bool Prefix(Dictionary<string, Functor> ___functorsMap, string name, Functor functor)
            {
                switch (name)
                {
                    case "BindItems":
                    case "BindMerchant":
                    case "DisplayLore":
                    case "EnvironmentEffect":
                    case "ForceBanterLine":
                    case "GrantExperience":
                    case "InventoryLoot":
                    case "OpenMerchant":
                    case "QuitLocation":
                    case "RemoveMonsters":
                    case "SpawnEncounter":
                    case "StartLongRest":
                    case "Teleport":
                        ___functorsMap.Add(name, new FunctorTrap(name, functor));
                        return false;

                    // this is a special case to get all possible stimulus (enable/disable/activate/deactivate)
                    case "UserGadgetOperation":
                        ___functorsMap.Add(name, new MyFunctorUserGadgetOperation());
                        return false;
                    
                    default:
                       return true;
                }
            }
        }
    }
}