using System;

namespace SolastaDungeonMakerPro.Models
{
    internal static class CheatsContext
    {
        public static void SetPartyInvicible(bool invincible)
        {
            var gameLocationCharacterService = ServiceRepository.GetService<IGameLocationCharacterService>();

            if (gameLocationCharacterService != null)
            {
                foreach (var partyCharacter in gameLocationCharacterService.PartyCharacters)
                {
                    if (invincible && !partyCharacter.RulesetCharacter.HasConditionOfCategoryAndType("15Debug", "ConditionDebugInvicible"))
                    {
                        RulesetCondition condition = RulesetCondition.CreateCondition(partyCharacter.RulesetCharacter.Guid, DatabaseRepository.GetDatabase<ConditionDefinition>().GetElement("ConditionDebugInvicible"));
                        partyCharacter.RulesetCharacter.AddConditionOfCategory("15Debug", condition);
                    }
                    else if (!invincible && partyCharacter.RulesetCharacter.HasConditionOfCategoryAndType("15Debug", "ConditionDebugInvicible"))
                    {
                        partyCharacter.RulesetCharacter.RemoveAllConditionsOfCategoryAndType("15Debug", "ConditionDebugInvicible");
                    }   
                }
            }
        }

        public static void SetFogOfWar(bool disabled)
        {
            var service = ServiceRepository.GetService<IGraphicsLocationPostProcessService>();

            if (service != null)
            {
                service.FowEnabled = !disabled;
            }
        }

        public static void SetMonstersIdle(bool idleEnemies)
        {
            if ((Object)Gui.GameLocation != (Object)null)
            {
                Gui.GameLocation.IdleEnemies = idleEnemies;
            }
        }
    }
}