using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityModManagerNet;
using ModKit;
using static SolastaDungeonMakerPro.Models.EncountersSpawnContext;

namespace SolastaDungeonMakerPro.Viewers
{
    public class EncountersViewer : IMenuSelectablePage
    {
        public string Name => "Encounters";

        public int Priority => 3;

        private static int selectedPane = 0;
        private static bool showStats = false;
        private static bool showAttributes = false;
        private static readonly Dictionary<MonsterDefinition, bool> currentFeaturesMonster = new Dictionary<MonsterDefinition, bool> { };
        private static readonly Dictionary<MonsterDefinition, bool> currentAttacksMonster = new Dictionary<MonsterDefinition, bool> { };
        private static readonly Dictionary<RulesetCharacterHero, bool> currentItemsHeroes = new Dictionary<RulesetCharacterHero, bool> { };

        private static string SplitCamelCase(string str)
        {
            return Regex.Replace(
                Regex.Replace(
                    str,
                    @"(\P{Ll})(\P{Ll}\p{Ll})",
                    "$1 $2"
                ),
                @"(\p{Ll})(\P{Ll})",
                "$1 $2"
            );
        }

        private static void DisplayHeroStats(RulesetCharacterHero hero, string actionText, System.Action action)
        {
            var flip = false;
            var inventory = hero.CharacterInventory.EnumerateAllSlots(false, true);

            using (UI.HorizontalScope())
            {
                UI.ActionButton(actionText.bold().red(), action, UI.Width(30));
                UI.Label($"{hero.Name} {hero.SurName}".orange().bold(), UI.Width(240));

                UI.Label($"{hero.RaceDefinition.FormatTitle()} {hero.ClassesHistory[0].FormatTitle()}".white(), UI.Width(120));

                var attributesLabel = showAttributes ? "" : "Atributes";
                UI.DisclosureToggle(attributesLabel, ref showAttributes, attributesLabel.Length * 12);

                if (showAttributes)
                {
                    UI.Label($"Str: {hero.GetAttribute("Strength").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Con: {hero.GetAttribute("Constitution").CurrentValue:0#}".yellow(), UI.Width(48));
                    UI.Label($"Dex: {hero.GetAttribute("Dexterity").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Int: {hero.GetAttribute("Intelligence").CurrentValue:0#}".yellow(), UI.Width(48));
                    UI.Label($"Wis: {hero.GetAttribute("Wisdom").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"Cha: {hero.GetAttribute("Charisma").CurrentValue:0#}".yellow(), UI.Width(48));
                };

                var statsLabel = showStats ? "" : "Stats";
                UI.DisclosureToggle(statsLabel, ref showStats, statsLabel.Length * 12);

                if (showStats)
                {
                    UI.Label($"AC: {hero.GetAttribute("ArmorClass").CurrentValue:0#}".white(), UI.Width(48));
                    UI.Label($"HD: {hero.MaxHitDiceCount():0#}{hero.MainHitDie}".yellow(), UI.Width(72));
                    UI.Label($"XP: {hero.GetAttribute("Experience").CurrentValue}".white(), UI.Width(72));
                    UI.Label($"LV: {hero.GetAttribute("CharacterLevel").CurrentValue:0#}".white(), UI.Width(48));
                }

                currentItemsHeroes.TryGetValue(hero, out flip);
                if (UI.DisclosureToggle($"Inventory", ref flip, 132))
                {
                    currentItemsHeroes.AddOrReplace<RulesetCharacterHero, bool>(hero, flip);
                }
            }

            currentItemsHeroes.TryGetValue(hero, out flip);
            if (flip)
                using (UI.VerticalScope())
                {
                    using (UI.HorizontalScope())
                    {
                        UI.Space(30);
                        UI.Label("Inventory".bold().cyan());
                    }
                    foreach (var slot in inventory)
                    {
                        if (slot.EquipedItem != null)
                            using (UI.HorizontalScope())
                            {
                                UI.Space(60);
                                UI.Label(slot.EquipedItem.ItemDefinition.FormatTitle(), UI.Width(192));
                            }
                    }
                }
        }

        private static void DisplayMonsterStats(MonsterDefinition monsterDefinition, string actionText, System.Action action)
        {
            var flip = false;

            using (UI.HorizontalScope())
            {
                UI.ActionButton(actionText.bold().red(), action, UI.Width(30));

                UI.Label($"{monsterDefinition.FormatTitle()}".orange().bold(), UI.Width(240));
                UI.Label($"{SplitCamelCase(monsterDefinition.Alignment)}".white(), UI.Width(120));

                var attributesLabel = showAttributes ? "" : "Atributes";
                UI.DisclosureToggle(attributesLabel, ref showAttributes, attributesLabel.Length * 12);

                if (showAttributes)
                {
                    UI.Label($"Str: {monsterDefinition.AbilityScores[0]:0#}".white(), UI.Width(48));
                    UI.Label($"Con: {monsterDefinition.AbilityScores[1]:0#}".yellow(), UI.Width(48));
                    UI.Label($"Dex: {monsterDefinition.AbilityScores[2]:0#}".white(), UI.Width(48));
                    UI.Label($"Int: {monsterDefinition.AbilityScores[3]:0#}".yellow(), UI.Width(48));
                    UI.Label($"Wis: {monsterDefinition.AbilityScores[4]:0#}".white(), UI.Width(48));
                    UI.Label($"Cha: {monsterDefinition.AbilityScores[5]:0#}".yellow(), UI.Width(48));
                };

                var statsLabel = showStats ? "" : "Stats";
                UI.DisclosureToggle(statsLabel, ref showStats, statsLabel.Length * 12);

                if (showStats)
                {
                    UI.Label($"AC: {monsterDefinition.ArmorClass}".white(), UI.Width(48));
                    UI.Label($"HD: {monsterDefinition.HitDice:0#}{monsterDefinition.HitDiceType}".yellow(), UI.Width(72));
                    UI.Label($"CR: {monsterDefinition.ChallengeRating}".yellow(), UI.Width(72));
                }


                currentAttacksMonster.TryGetValue(monsterDefinition, out flip);
                if (UI.DisclosureToggle($"Attacks ({monsterDefinition.AttackIterations.Count:0#})", ref flip, 132))
                {
                    currentAttacksMonster.AddOrReplace<MonsterDefinition, bool>(monsterDefinition, flip);
                }

                currentFeaturesMonster.TryGetValue(monsterDefinition, out flip);
                if (UI.DisclosureToggle($"Features ({monsterDefinition.Features.Count:0#})", ref flip, 144))
                {
                    currentFeaturesMonster.AddOrReplace<MonsterDefinition, bool>(monsterDefinition, flip);
                }
            };

            currentFeaturesMonster.TryGetValue(monsterDefinition, out flip);
            if (flip)
                using (UI.VerticalScope())
                {
                    using (UI.HorizontalScope())
                    {
                        UI.Space(30);
                        UI.Label("Features".bold().cyan());
                    }
                    foreach (var feature in monsterDefinition.Features)
                        using (UI.HorizontalScope())
                        {
                            var title = feature.FormatTitle();
                            if (title == "None") title = SplitCamelCase(feature.Name);
                            UI.Space(60);
                            UI.Label(title, UI.Width(192));
                        }
                }

            currentAttacksMonster.TryGetValue(monsterDefinition, out flip);
            if (flip)
                using (UI.VerticalScope())
                {
                    using (UI.HorizontalScope())
                    {
                        UI.Space(30);
                        UI.Label("Attacks".bold().cyan());
                    }
                    foreach (var attackIteration in monsterDefinition.AttackIterations)
                        using (UI.HorizontalScope())
                        {
                            var title = attackIteration.MonsterAttackDefinition.FormatTitle();
                            if (title == "None") title = SplitCamelCase(attackIteration.MonsterAttackDefinition.name);
                            UI.Space(60);
                            UI.Label(title, UI.Width(192));
                            UI.Label($"action type: {attackIteration.MonsterAttackDefinition.ActionType.ToString()}".green(), UI.Width(120));
                            UI.Label($"reach: {attackIteration.MonsterAttackDefinition.ReachRange.ToString()}".green(), UI.Width(108));
                            UI.Label($"hit bonus: {attackIteration.MonsterAttackDefinition.ToHitBonus.ToString()}".green(), UI.Width(108));
                            if (attackIteration.MonsterAttackDefinition.MaxUses < 0)
                            {
                                UI.Label($"max uses: inf".green(), UI.Width(108));
                            }
                            else
                            {
                                UI.Label($"max uses: {attackIteration.MonsterAttackDefinition.MaxUses.ToString()}".green(), UI.Width(108));
                            }
                            if (attackIteration.MonsterAttackDefinition.Magical)
                            {
                                UI.Label($"MAGICAL".green(), UI.Width(108));
                            }
                        }
                }
        }

        private static void DisplayEncounterTable()
        {
            using (UI.VerticalScope(UI.AutoWidth(), UI.AutoHeight()))
            {
                UI.Label("");
                UI.Label("Pan the camera to the desired encounter location and press".yellow().bold() + " CTRL-SHIFT-E ".green().bold() + "to spawn".yellow().bold(), UI.AutoWidth());

                UI.Label("");
                if (EncounterCharacters.Count == 0)
                {
                    UI.Label("Encounter table is empty...");
                }
                else
                {
                    for (var index = 0; index < EncounterCharacters.Count; index++)
                    {
                        if (EncounterCharacters[index] is RulesetCharacterMonster rulesetCharacterMonster)
                        {
                            DisplayMonsterStats(rulesetCharacterMonster.MonsterDefinition, "-", () => { RemoveFromEncounter(index); });
                        }
                        else if (EncounterCharacters[index] is RulesetCharacterHero rulesetCharacterHero)
                        {
                            DisplayHeroStats(rulesetCharacterHero, "-", () => { RemoveFromEncounter(index); });
                        }
                    }
                }
            }
        }

        private static void DisplayBestiary()
        {
            using (UI.VerticalScope(UI.AutoWidth(), UI.AutoHeight()))
            {
                UI.Label("");
                UI.Label($"Press + to add up to {Settings.MAX_ENCOUNTER_CHARACTERS} characters to the encounter list...".yellow().bold());

                UI.Label("");
                foreach (var monsterDefinition in GetMonsters())
                {
                    DisplayMonsterStats(monsterDefinition, "+", () => { AddToEncounter(monsterDefinition); });
                }
            }
        }

        private static void DisplayNPCs()
        {
            using (UI.VerticalScope(UI.AutoWidth(), UI.AutoHeight()))
            {
                UI.Label("");
                UI.Label($"Press + to add up to {Settings.MAX_ENCOUNTER_CHARACTERS} characters to the encounter list...".yellow().bold());

                UI.Label("");
                foreach (var hero in GetHeroes())
                {
                    DisplayHeroStats(hero, "+", () => { AddToEncounter(hero); });
                }
            }
        }

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            UI.Label("Welcome to Dungeon Maker Pro".yellow().bold());
            UI.Div();

            if (!Main.Enabled) return;

            UI.TabBar(ref selectedPane, null, new NamedAction[] {
                new NamedAction("Encounter", DisplayEncounterTable),
                new NamedAction("Bestiary", DisplayBestiary),
                new NamedAction("NPCs", DisplayNPCs)
            });
        }
    }
}