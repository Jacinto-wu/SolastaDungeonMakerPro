using MoonSharp.Interpreter;

namespace SolastaDungeonMakerPro.Models.Scripting
{
    public class Utils
    {
        public static void SetInt(string variable, int value)
        {
            var gameVariableService = ServiceRepository.GetService<IGameVariableService>();
            var variableName = variable.ToUpper();

            if (gameVariableService != null)
            {
                if (gameVariableService.IsVariableRegistered(variableName))
                {
                    gameVariableService.ActiveVariables.Find(x => x.Name == variableName).IntValue = value;
                }
                else
                {
                    gameVariableService.RegisterVariable(variableName, GameVariableDefinitions.Scope.Campaign, value);
                }
            }
        }

        public static DynValue GetInt(string variable)
        {
            var gameVariableService = ServiceRepository.GetService<IGameVariableService>();
            var variableName = variable?.ToUpper();

            if (gameVariableService != null && variableName != null)
            {
                if (gameVariableService.IsVariableRegistered(variableName))
                {
                    return DynValue.NewNumber(gameVariableService.ActiveVariables.Find(x => x.Name == variableName).IntValue);
                }
                else
                {
                    gameVariableService.RegisterVariable(variableName, GameVariableDefinitions.Scope.Campaign, 0);
                    return DynValue.NewNumber(0);
                }
            }

            return DynValue.NewNumber(-9999);
        }

        public static void SetStr(string variable, string value)
        {
            var gameVariableService = ServiceRepository.GetService<IGameVariableService>();
            var variableName = variable.ToUpper();

            if (gameVariableService != null)
            {
                if (gameVariableService.IsVariableRegistered(variableName))
                {
                    gameVariableService.ActiveVariables.Find(x => x.Name == variableName).StringValue = value;
                }
                else
                {
                    gameVariableService.RegisterVariable(variableName, GameVariableDefinitions.Scope.Campaign, value);
                }
            }
        }

        public static DynValue GetStr(string variable)
        {
            var gameVariableService = ServiceRepository.GetService<IGameVariableService>();
            var variableName = variable.ToUpper();

            if (gameVariableService != null && variableName != null)
            {
                if (gameVariableService.IsVariableRegistered(variableName))
                {
                    return DynValue.NewString(gameVariableService.ActiveVariables.Find(x => x.Name == variableName).StringValue);
                }
                else
                {
                    gameVariableService.RegisterVariable(variableName, GameVariableDefinitions.Scope.Campaign, string.Empty);
                    return DynValue.NewString(string.Empty);
                }
            }

            return DynValue.NewString("err");
        }

        public static void Log(string message)
        {
            Main.Warning($"[Lua]:{message}");
        }

        public int Result = -1;

        public void Message(string messageTitle, string messageDescription, string validatedTitle = "Message/&MessageYesTitle")
        {
            Result = -1;

            try
            {
                Gui.GuiService.ShowMessage(MessageModal.Severity.Informative1, messageTitle, messageDescription, validatedTitle, "",
                    new MessageModal.MessageValidatedHandler(() => { Result = 1; }),
                    null);
            }
            catch
            {
                Main.Warning("Lua scripting execution error on Message");
            }
        }

        public void Confirm(string confirmationTitle, string confirmationDescription, string validatedTitle = "Message/&MessageYesTitle", string cancelledTitle = "Message/&MessageNoTitle")
        {
            Result = -1;

            try
            {
                Gui.GuiService.ShowMessage(MessageModal.Severity.Attention2, confirmationTitle, confirmationDescription, validatedTitle, cancelledTitle,
                    new MessageModal.MessageValidatedHandler(() => { Result = 1; }),
                    new MessageModal.MessageCancelledHandler(() => { Result = 0; }));
            }
            catch
            {
                Main.Warning("Lua scripting execution error on Confirm");
            }
        }

        public void Tell(string alertDescription, string color = "FFFFFF")
        {
            try
            {
                Gui.GuiService.ShowAlert(alertDescription, color);
            }
            catch
            {
                Main.Warning("Lua scripting execution error on Tell");
            }
        }

        public bool AddGuest(string guestName)
        {
            var gameService = ServiceRepository.GetService<IGameService>();
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
            var gameLocationCharacter = gameLocationCharacterService.AllValidEntities.Find(x => x.RulesetCharacter != null && x.RulesetCharacter.Name == guestName);

            if (gameService != null && gameLocationCharacter != null)
            {
                gameLocationCharacter.ChangeSide(RuleDefinitions.Side.Ally);
                gameLocationCharacterService.AddGuest(gameLocationCharacter);
                gameLocationCharacterService.UpdateAllSides();

                return true;
            }

            return false;
        }

        public bool RemoveGuest(string guestName)
        {
            var gameService = ServiceRepository.GetService<IGameService>();
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
            var gameLocationCharacter = gameLocationCharacterService.AllValidEntities.Find(x => x.RulesetCharacter != null && x.RulesetCharacter.Name == guestName);
            var gameCampaignCharacter = gameService?.Game.GameCampaign.Party.GuestCharactersList.Find(x => x.RulesetCharacter.Name == guestName);

            if (gameService != null && gameLocationCharacter != null)
            {
                var removeGuestMethod = typeof(IGameLocationCharacterService).GetMethod("RemoveGuest", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

                gameLocationCharacter.ChangeSide(RuleDefinitions.Side.Neutral);
                gameLocationCharacterService.UpdateAllSides();

                return true;
            }

            return false;
        }

        public void MoveNPC(string name, int locX, int locZ)
        {
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();
            var gameLocationCharacter = gameLocationCharacterService.AllValidEntities.Find(x => x.RulesetCharacter != null && x.RulesetCharacter.Name == name);

            if (gameLocationCharacter != null)
            {
                gameLocationCharacterService.RemoveCharacterFromTheGame(gameLocationCharacter);
                gameLocationCharacter.LocationPosition = new TA.int3(locX, 0, locZ);
                gameLocationCharacterService.ReturnCharacterToTheGame(gameLocationCharacter);
            }
        }
    }
}