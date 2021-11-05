using System.Collections.Generic;

namespace SolastaDungeonMakerPro.Models.Scripting
{
    public class Actor
    {
        private readonly RulesetCharacter actor;

        public Actor(GameLocationCharacter gameLocationCharacter)
        {
            actor = gameLocationCharacter?.RulesetCharacter;
        }

        private int Attribute(string name)
        {
            var result = 0;

            if (actor != null && actor.Attributes.ContainsKey(name))
            {
                result = actor.Attributes[name].CurrentValue;
            }

            return result;
        }

        public string Name
        {
            get => actor != null ? actor.Name : string.Empty;
        }

        public string SurName
        {
            get => actor != null && actor is RulesetCharacterHero hero ? hero.SurName : string.Empty;
        }

        public string Class
        {
            get => actor != null && actor is RulesetCharacterHero hero ? hero.ClassesHistory[0].Name : string.Empty;
        }

        public string Race
        {
            get => actor != null && actor is RulesetCharacterHero hero ? hero.RaceDefinition.Name : string.Empty;
        }

        public string SubRace
        {
            get => actor != null && actor is RulesetCharacterHero hero ? hero.SubRaceDefinition.Name : string.Empty;
        }

        public int HitPoints { get => actor == null ? 0 : actor.CurrentHitPoints; }

        public int Lvl { get => Attribute("CharacterLevel"); }

        public int Exp { get => Attribute("Experience"); }

        public int Str { get => Attribute("Strength"); }

        public int Dex { get => Attribute("Dexterity"); }

        public int Con { get => Attribute("Constitution"); }

        public int Int { get => Attribute("Intelligence"); }

        public int Wis { get => Attribute("Wisdom"); }

        public int Cha { get => Attribute("Charisma"); }

        public List<RulesetCondition> Conditions => actor.AllConditions;

        public Dictionary<string, List<RulesetCondition>> ConditionsByCategory { get => actor.ConditionsByCategory; }

        public bool CanCastSpells { get => actor != null && actor is RulesetCharacterHero hero ? hero.CanCastSpells() : false; }

        public bool CanCastAnyRitualSpell { get => actor != null && actor is RulesetCharacterHero hero ? hero.CanCastAnyRitualSpell() : false; }

        public bool HasItem(ItemDefinition itemDefinition) => actor.CarriesItemOfDefinition(itemDefinition);

        public bool GrantItem(ItemDefinition itemDefinition, int quantity = 1) => actor.GrantItem(itemDefinition, false, quantity);

        public void LoseItem(ItemDefinition itemDefinition, bool all = false) => actor.LoseItem(itemDefinition, all);

        public void Awaken() => actor.Awaken();

        public void BreakConcentration() => actor.BreakConcentration();

        public RuleDefinitions.Side Side
        {
            get => actor.side;
            set => actor.side = value;
        }

        //public bool Invisible
        //{
        //    get => actor.CheatIsInvisible;
        //    set => actor.CheatIsInvisible = value;
        //}

        //public bool InfiniteActions
        //{
        //    get => actor.CheatInfiniteActionResources;
        //    set => actor.CheatInfiniteActionResources = value;
        //}
    }
}