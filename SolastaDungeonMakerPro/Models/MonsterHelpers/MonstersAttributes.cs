using System.Collections.Generic;
using SolastaModApi;
using SolastaModApi.Extensions; 
using SolastaModApi.Infrastructure;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace SolastaDungeonMakerPro.Models.MonsterHelpers
{
    public class MonstersAttributes
    {

        static public MonsterAttackIteration BlackDragonBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration BlueDragonBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration GreenDragonBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration RedDragonBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration WhiteDragonBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration DragonClawAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration DragonClawAttackIteration_2 = new MonsterAttackIteration();
        static public LegendaryActionDescription DragonlegendaryActionDescription = new LegendaryActionDescription();
        static public LegendaryActionDescription DragonlegendaryActionDescription_2 = new LegendaryActionDescription();
        static public MonsterSkillProficiency DragonmonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency DragonmonsterSkillProficiency_2 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency GreenDragonmonsterSkillProficiency_3 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency GreenDragonmonsterSkillProficiency_4 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency GreenDragonmonsterSkillProficiency_5 = new MonsterSkillProficiency();

        static public MonsterSkillProficiency ArchmagemonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency ArchmagemonsterSkillProficiency_2 = new MonsterSkillProficiency();

        static public AssetReference BalorassetReference = new AssetReference();
        static public MonsterAttackIteration BalorLongswordAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration BalorWhipAttackIteration = new MonsterAttackIteration();

        static public MonsterSkillProficiency DevamonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency DevamonsterSkillProficiency_2 = new MonsterSkillProficiency();

        static public AssetReference DjinniassetReference = new AssetReference();
        static public MonsterAttackIteration DjinniAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration DjinniAttackIteration_2 = new MonsterAttackIteration();

        static public AssetReference EfreetiassetReference = new AssetReference();
        static public MonsterAttackIteration EfreetiAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration EfreetiAttackIteration_2 = new MonsterAttackIteration();

        static public MonsterAttackIteration ErinyesAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration ErinyesAttackIteration_2 = new MonsterAttackIteration();

        static public MonsterAttackIteration NagaAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration NagaAttackIteration_2 = new MonsterAttackIteration();

        static public MonsterAttackIteration HornedDevilForkAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration HornedDevilClawAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration HornedDevilTailAttackIteration = new MonsterAttackIteration();

        static public MonsterAttackIteration IceDevilBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration IceDevilClawAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration IceDevilTailAttackIteration = new MonsterAttackIteration();

        static public MonsterAttackIteration LichAttackIteration = new MonsterAttackIteration();
        static public LegendaryActionDescription LichlegendaryActionDescription_0 = new LegendaryActionDescription();
        static public LegendaryActionDescription LichlegendaryActionDescription_4 = new LegendaryActionDescription();
        static public LegendaryActionDescription LichlegendaryActionDescription = new LegendaryActionDescription();
        static public LegendaryActionDescription LichlegendaryActionDescription_2 = new LegendaryActionDescription();
        static public LegendaryActionDescription LichlegendaryActionDescription_3 = new LegendaryActionDescription();
        static public MonsterSkillProficiency LichmonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency LichmonsterSkillProficiency_2 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency LichmonsterSkillProficiency_3 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency LichmonsterSkillProficiency_4 = new MonsterSkillProficiency();
        static public AssetReference LichassetReference = new AssetReference();

        static public MonsterAttackIteration NalfeshneeBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration NalfeshneeClawAttackIteration = new MonsterAttackIteration();

        static public MonsterAttackIteration PitFiendBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration PitFiendClawAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration PitFiendTailAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration PitFiendWeaponAttackIteration = new MonsterAttackIteration();


        static public MonsterAttackIteration PlanetarLongswordAttackIteration = new MonsterAttackIteration();
        static public MonsterSkillProficiency PlanetarmonsterSkillProficiency_1 = new MonsterSkillProficiency();

        static public MonsterAttackIteration RocBiteAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration RocClawAttackIteration = new MonsterAttackIteration();
        static public MonsterSkillProficiency RocmonsterSkillProficiency_1 = new MonsterSkillProficiency();

        static public MonsterAttackIteration SolarLongswordAttackIteration = new MonsterAttackIteration();
        static public MonsterAttackIteration SolarLongbowAttackIteration = new MonsterAttackIteration();
        static public LegendaryActionDescription SolarlegendaryActionDescription = new LegendaryActionDescription();
        static public LegendaryActionDescription SolarlegendaryActionDescription_2 = new LegendaryActionDescription();
        static public LegendaryActionDescription SolarlegendaryActionDescription_3 = new LegendaryActionDescription();
        static public MonsterSkillProficiency SolarmonsterSkillProficiency_1 = new MonsterSkillProficiency();

        static public MonsterSkillProficiency StormGiantmonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency StormGiantmonsterSkillProficiency_2 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency StormGiantmonsterSkillProficiency_3 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency StormGiantmonsterSkillProficiency_4 = new MonsterSkillProficiency();


        static public LegendaryActionDescription VampirelegendaryActionDescription = new LegendaryActionDescription();
        static public LegendaryActionDescription VampirelegendaryActionDescription_2 = new LegendaryActionDescription();
        //static public  LegendaryActionDescription VampirelegendaryActionDescription_3 = new LegendaryActionDescription();
        static public LegendaryActionDescription VampirelegendaryActionDescription_4 = new LegendaryActionDescription();
        static public MonsterSkillProficiency VampiremonsterSkillProficiency_1 = new MonsterSkillProficiency();
        static public MonsterSkillProficiency VampiremonsterSkillProficiency_2 = new MonsterSkillProficiency();

        static public AssetReference EmptyassetReference = new AssetReference();







        public static void EnableInDungeonMaker()
        {

            BlackDragonBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.DictionaryOfAncientDragonBites["Ancient Black Dragon"]);
            BlackDragonBiteAttackIteration.SetField("number", 1);

            BlueDragonBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.DictionaryOfAncientDragonBites["Ancient Blue Dragon"]);
            BlueDragonBiteAttackIteration.SetField("number", 1);

            GreenDragonBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.DictionaryOfAncientDragonBites["Ancient Green Dragon"]);
            GreenDragonBiteAttackIteration.SetField("number", 1);

            RedDragonBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.DictionaryOfAncientDragonBites["Ancient Red Dragon"]);
            RedDragonBiteAttackIteration.SetField("number", 1);

            WhiteDragonBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.DictionaryOfAncientDragonBites["Ancient White Dragon"]);
            WhiteDragonBiteAttackIteration.SetField("number", 1);

            DragonClawAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.AncientDragon_Claw_Attack);
            DragonClawAttackIteration.SetField("number", 1);

            DragonClawAttackIteration_2.SetField("monsterAttackDefinition", NewMonsterAttacks.AncientDragon_Claw_Attack);
            DragonClawAttackIteration_2.SetField("number", 1);

            DragonlegendaryActionDescription.SetCost(2);
            DragonlegendaryActionDescription.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            DragonlegendaryActionDescription.SetCanMove(true);
            DragonlegendaryActionDescription.SetMoveMode(DatabaseHelper.FeatureDefinitionMoveModes.MoveModeFly6);
            DragonlegendaryActionDescription.SetFeatureDefinitionPower(NewMonsterPowers.AncientDragon_Wing_Power);
            DragonlegendaryActionDescription.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDragonWingAttack);

            DragonlegendaryActionDescription_2.SetCost(1);
            DragonlegendaryActionDescription_2.SetSubaction(LegendaryActionDescription.SubactionType.MonsterAttack);
            DragonlegendaryActionDescription_2.SetMonsterAttackDefinition(NewMonsterAttacks.AncientDragon_Tail_Attack);
            DragonlegendaryActionDescription_2.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDragonAttack);

            DragonmonsterSkillProficiency_1.SetField("skillName", "Perception");
            DragonmonsterSkillProficiency_1.SetField("bonus", 16);
            DragonmonsterSkillProficiency_2.SetField("skillName", "Stealth");
            DragonmonsterSkillProficiency_2.SetField("bonus", 8);

            GreenDragonmonsterSkillProficiency_3.SetField("skillName", "Persuasion");
            GreenDragonmonsterSkillProficiency_3.SetField("bonus", 11);            
            GreenDragonmonsterSkillProficiency_4.SetField("skillName", "Deception");
            GreenDragonmonsterSkillProficiency_4.SetField("bonus", 11);
            GreenDragonmonsterSkillProficiency_5.SetField("skillName", "Insight");
            GreenDragonmonsterSkillProficiency_5.SetField("bonus", 10);

            ArchmagemonsterSkillProficiency_1.SetField("skillName", "Arcana");
            ArchmagemonsterSkillProficiency_1.SetField("bonus", 13);

            ArchmagemonsterSkillProficiency_2.SetField("skillName", "History");
            ArchmagemonsterSkillProficiency_2.SetField("bonus", 13);

            BalorassetReference.SetField("m_AssetGUID", "5d249b514baa99040874880ba8d35295");

            BalorLongswordAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Balor_Longsword_Attack);
            BalorLongswordAttackIteration.SetField("number", 1);

            BalorWhipAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Balor_Whip_Attack);
            BalorWhipAttackIteration.SetField("number", 1);

            DevamonsterSkillProficiency_1.SetField("skillName", "Insight");
            DevamonsterSkillProficiency_1.SetField("bonus", 9);

            DevamonsterSkillProficiency_2.SetField("skillName", "Perception");
            DevamonsterSkillProficiency_2.SetField("bonus", 9);

            DjinniassetReference.SetField("m_AssetGUID", "2a2913c5eec57a24da4af020cf0e0f0f");

            DjinniAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.LightningScimatar_Attack);
            DjinniAttackIteration.SetField("number", 3);

            DjinniAttackIteration_2.SetField("monsterAttackDefinition", NewMonsterAttacks.AirBlast_Attack);
            DjinniAttackIteration_2.SetField("number", 3);

            EfreetiassetReference.SetField("m_AssetGUID", "5d249b514baa99040874880ba8d35295");

            EfreetiAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.FireScimatar_Attack);
            EfreetiAttackIteration.SetField("number", 2);

            EfreetiAttackIteration_2.SetField("monsterAttackDefinition", NewMonsterAttacks.HurlFlame_Attack);
            EfreetiAttackIteration_2.SetField("number", 2);

            ErinyesAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.PoisonLongsword_Attack);
            ErinyesAttackIteration.SetField("number", 3);

            ErinyesAttackIteration_2.SetField("monsterAttackDefinition", NewMonsterAttacks.PoisonLongbow_Attack);
            ErinyesAttackIteration_2.SetField("number", 3);

            NagaAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.NagaSpit_Attack);
            NagaAttackIteration.SetField("number", 1);

            NagaAttackIteration_2.SetField("monsterAttackDefinition", NewMonsterAttacks.NagaBite_Attack);
            NagaAttackIteration_2.SetField("number", 1);

            HornedDevilForkAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Fork_Attack);
            HornedDevilForkAttackIteration.SetField("number", 1);

            HornedDevilClawAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.HurlFlame_Attack);
            HornedDevilClawAttackIteration.SetField("number", 1);

            HornedDevilTailAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.HornedDevilTail_Attack);
            HornedDevilTailAttackIteration.SetField("number", 1);

            IceDevilBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Ice_Bite_Attack);
            IceDevilBiteAttackIteration.SetField("number", 1);

            IceDevilClawAttackIteration.SetField("monsterAttackDefinition", DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Claw);
            IceDevilClawAttackIteration.SetField("number", 1);

            IceDevilTailAttackIteration.SetField("monsterAttackDefinition", DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Tail);
            IceDevilTailAttackIteration.SetField("number", 1);

            LichAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Lich_ParalyzingTouch_Attack);
            LichAttackIteration.SetField("number", 1);

            LichassetReference.SetField("m_AssetGUID", "5bbe5d35725c2cc4492672476f4fc783");
            
            LichlegendaryActionDescription_0.SetCost(1);
            LichlegendaryActionDescription_0.SetSubaction(LegendaryActionDescription.SubactionType.Spell);
            LichlegendaryActionDescription_0.SetSpellDefinition(DatabaseHelper.SpellDefinitions.RayOfFrost);
            LichlegendaryActionDescription_0.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Debuff);

            LichlegendaryActionDescription_4.SetCost(1);
            LichlegendaryActionDescription_4.SetSubaction(LegendaryActionDescription.SubactionType.Spell);
            LichlegendaryActionDescription_4.SetSpellDefinition(DatabaseHelper.SpellDefinitions.ChillTouch);
            LichlegendaryActionDescription_4.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Debuff);

            LichlegendaryActionDescription.SetCost(2);
            LichlegendaryActionDescription.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            LichlegendaryActionDescription.SetFeatureDefinitionPower(DatabaseHelper.FeatureDefinitionPowers.PowerLaetharParalyzingGaze);
            LichlegendaryActionDescription.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Debuff);

            LichlegendaryActionDescription_2.SetCost(2);
            LichlegendaryActionDescription_2.SetSubaction(LegendaryActionDescription.SubactionType.MonsterAttack);
            LichlegendaryActionDescription_2.SetMonsterAttackDefinition(NewMonsterAttacks.Lich_ParalyzingTouch_Attack);
            LichlegendaryActionDescription_2.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDragonAttack);

            LichlegendaryActionDescription_3.SetCost(3);
            LichlegendaryActionDescription_3.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            LichlegendaryActionDescription_3.SetFeatureDefinitionPower(NewMonsterPowers.Lich_DisruptLife_Power);
            LichlegendaryActionDescription_3.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryAoE_DpS);

            LichmonsterSkillProficiency_1.SetField("skillName", "Arcana");
            LichmonsterSkillProficiency_1.SetField("bonus", 19);

            LichmonsterSkillProficiency_2.SetField("skillName", "History");
            LichmonsterSkillProficiency_2.SetField("bonus", 12);

            LichmonsterSkillProficiency_3.SetField("skillName", "Insight");
            LichmonsterSkillProficiency_3.SetField("bonus", 9);

            LichmonsterSkillProficiency_4.SetField("skillName", "Perception");
            LichmonsterSkillProficiency_4.SetField("bonus", 9);

            NalfeshneeBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Generic_Stronger_Bite_Attack);
            NalfeshneeBiteAttackIteration.SetField("number", 1);

            NalfeshneeClawAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.AncientDragon_Claw_Attack);
            NalfeshneeClawAttackIteration.SetField("number", 1);

            PitFiendBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.PitFiend_Bite_Attack);
            PitFiendBiteAttackIteration.SetField("number", 1);

            PitFiendClawAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.AncientDragon_Claw_Attack);
            PitFiendClawAttackIteration.SetField("number", 1);

            PitFiendTailAttackIteration.SetField("monsterAttackDefinition", DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Tail);
            PitFiendTailAttackIteration.SetField("number", 1);

            PitFiendWeaponAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.PitFiend_Mace_Attack);
            PitFiendWeaponAttackIteration.SetField("number", 1);

            PlanetarLongswordAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.RadiantLongsword_Attack);
            PlanetarLongswordAttackIteration.SetField("number", 2);

            PlanetarmonsterSkillProficiency_1.SetField("skillName", "Perception");
            PlanetarmonsterSkillProficiency_1.SetField("bonus", 11);

            RocBiteAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Roc_Beak_Attack);
            RocBiteAttackIteration.SetField("number", 1);

            RocClawAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.Roc_Talons_Attack);
            RocClawAttackIteration.SetField("number", 1);

            RocmonsterSkillProficiency_1.SetField("skillName", "Perception");
            RocmonsterSkillProficiency_1.SetField("bonus", 4);

            SolarLongswordAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.RadiantLongsword_Attack);
            SolarLongswordAttackIteration.SetField("number", 2);

            SolarLongbowAttackIteration.SetField("monsterAttackDefinition", NewMonsterAttacks.RadiantLongbow_Attack);
            SolarLongbowAttackIteration.SetField("number", 2);

            SolarlegendaryActionDescription.SetCost(1);
            SolarlegendaryActionDescription.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            SolarlegendaryActionDescription.SetFeatureDefinitionPower(DatabaseHelper.FeatureDefinitionPowers.PowerLaetharMistyFormEscape);
            SolarlegendaryActionDescription.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Teleport);

            SolarlegendaryActionDescription_2.SetCost(2);
            SolarlegendaryActionDescription_2.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            SolarlegendaryActionDescription_2.SetFeatureDefinitionPower(NewMonsterPowers.SearingBurst_Power);
            SolarlegendaryActionDescription_2.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryAoE_DpS);

            SolarlegendaryActionDescription_3.SetCost(3);
            SolarlegendaryActionDescription_3.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            SolarlegendaryActionDescription_3.SetFeatureDefinitionPower(NewMonsterPowers.BlindingGaze_Power);
            SolarlegendaryActionDescription_3.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Debuff);

            SolarmonsterSkillProficiency_1.SetField("skillName", "Perception");
            SolarmonsterSkillProficiency_1.SetField("bonus", 14);
            StormGiantmonsterSkillProficiency_1.SetField("skillName", "Arcana");
            StormGiantmonsterSkillProficiency_1.SetField("bonus", 8);

            StormGiantmonsterSkillProficiency_2.SetField("skillName", "Athletics");
            StormGiantmonsterSkillProficiency_2.SetField("bonus", 14);

            StormGiantmonsterSkillProficiency_3.SetField("skillName", "History");
            StormGiantmonsterSkillProficiency_3.SetField("bonus", 8);

            StormGiantmonsterSkillProficiency_3.SetField("skillName", "Perception");
            StormGiantmonsterSkillProficiency_3.SetField("bonus", 9);

            VampirelegendaryActionDescription.SetCost(1);
            VampirelegendaryActionDescription.SetSubaction(LegendaryActionDescription.SubactionType.MonsterAttack);
            VampirelegendaryActionDescription.SetMonsterAttackDefinition(DatabaseHelper.MonsterAttackDefinitions.Attack_Defiler_Bite_Razan);
            VampirelegendaryActionDescription.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDefilerAttack);
            VampirelegendaryActionDescription.SetCanMove(true);
            VampirelegendaryActionDescription.SetMoveMode(DatabaseHelper.FeatureDefinitionMoveModes.MoveModeFly6);
            VampirelegendaryActionDescription.SetNoOpportunityAttack(true);

            VampirelegendaryActionDescription_2.SetCost(1);
            VampirelegendaryActionDescription_2.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            VampirelegendaryActionDescription_2.SetFeatureDefinitionPower(DatabaseHelper.FeatureDefinitionPowers.PowerDefilerDarkness);
            VampirelegendaryActionDescription_2.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDefilerDarkness);

            //  following would recreate a vampires ability to charm PC's when solasta monsters typically cant charm solasta characters but it's too OP to be a legendary action
            //
            //     VampirelegendaryActionDescription_3.SetCost(3);
            //     VampirelegendaryActionDescription_3.SetSubaction(LegendaryActionDescription.SubactionType.Spell);
            //     VampirelegendaryActionDescription_3.SetSpellDefinition(DatabaseHelper.SpellDefinitions.HypnoticPattern);
            //     VampirelegendaryActionDescription_3.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryDefilerAoE_Debuff);

            VampirelegendaryActionDescription_4.SetCost(3);
            VampirelegendaryActionDescription_4.SetSubaction(LegendaryActionDescription.SubactionType.Power);
            VampirelegendaryActionDescription_4.SetFeatureDefinitionPower(DatabaseHelper.FeatureDefinitionPowers.PowerLaetharParalyzingGaze);
            VampirelegendaryActionDescription_4.SetDecisionPackage(DatabaseHelper.DecisionPackageDefinitions.LegendaryLaetharCast_Debuff);

            VampiremonsterSkillProficiency_1.SetField("skillName", "Perception");
            VampiremonsterSkillProficiency_1.SetField("bonus", 7);

            VampiremonsterSkillProficiency_2.SetField("skillName", "Stealth");
            VampiremonsterSkillProficiency_2.SetField("bonus", 9);


            EmptyassetReference.SetField("m_AssetGUID", "");
            EmptyassetReference.SetField("m_SubObjectName", "");
            EmptyassetReference.SetField("m_SubObjectType", "");




        }


    }


   

}


