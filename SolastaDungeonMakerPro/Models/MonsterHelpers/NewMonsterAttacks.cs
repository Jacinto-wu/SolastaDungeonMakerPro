using System.Collections.Generic;
using SolastaModApi;
using SolastaModApi.Extensions;
using UnityEngine;
using static SolastaDungeonMakerPro.Models.MonsterContext;

namespace SolastaDungeonMakerPro.Models.MonsterHelpers
{
    public class NewMonsterAttacks
    {
        static public MonsterAttackDefinition FireScimatar_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition LightningScimatar_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition HurlFlame_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition AirBlast_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition PoisonLongsword_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition PoisonLongbow_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition RadiantLongsword_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition RadiantLongbow_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition NagaBite_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition NagaSpit_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Ice_Bite_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Roc_Beak_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Roc_Talons_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Generic_Bite_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition PitFiend_Bite_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition PitFiend_Mace_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Generic_Stronger_Bite_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition AncientDragon_Tail_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Fork_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition HornedDevilTail_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition AncientDragon_Claw_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Balor_Longsword_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Balor_Whip_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition Lich_ParalyzingTouch_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition FireTitan_Slam_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition AirTitan_Slam_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition EarthTitan_Slam_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition ConstructTitan_Slam_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition ConstructTitan_ForceCannon_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();
        static public MonsterAttackDefinition EarthTitan_Boulder_Attack = ScriptableObject.CreateInstance<MonsterAttackDefinition>();

        static public Dictionary<string, MonsterAttackDefinition> DictionaryOfAncientDragonBites = new Dictionary<string, MonsterAttackDefinition>();
        static public Dictionary<string, MonsterAttackDefinition> DictionaryOfGenericBitesWithExtraDamage = new Dictionary<string, MonsterAttackDefinition>();
 
        internal static void Create()
        {
            BuildNewIce_Bite_Attack();
            BuildNewPoisonLongsword_Attack();
            BuildNewPoisonLongbow_Attack();
            BuildNewRadiantLongsword_Attack();
            BuildNewRadiantLongbow_Attack();           
            BuildNewAirBlast_Attack();
            BuildNewHurlFlame_Attack();
            BuildNewFireScimatar_Attack();
            BuildNewLightningScimatar_Attack();
            BuildNewNagaBite_Attack();
            BuildNewNagaSpit_Attack();
            BuildNewRoc_Beak_Attack();
            BuildNewRoc_Talons_Attack();
            BuildNewFork_Attack();
            BuildNewHornedDevilTail_Attack();
            BuildNewGeneric_Bite_Attack();
            BuildNewGeneric_Stronger_Bite_Attack();
            BuildNewGeneric_Claw_Attack();
            BuildNew_AncientDragon_Bite_Attack();
            BuildNewAncientDragon_Tail_Attack();
            BuildNewPitFiend_Bite_Attack();
            BuildNew_PitFiend_Mace_Attack();
            BuildNewBalor_Longsword_Attack();
            BuildNewBalor_Whip_Attack();
            BuildNewLich_ParalyzingTouch_Attack();
            BuildNewAirTitan_Slam_Attack();
            BuildNewFireTitan_Slam_Attack();
            BuildNewEarthTitan_Boulder_Attack();
            BuildNewEarthTitan_Slam_Attack();
            BuildNewConstructTitan_Slam_Attack();
            BuildNewConstructTitan_ForceCannon_Attack();

        }

        public static void BuildNewRoc_Beak_Attack()
        {
            
            string text = "Roc_Beak_Attack";


            Roc_Beak_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_GiantEagle_Beak,            
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Roc_Beak_Attack.SetToHitBonus(13);
            Roc_Beak_Attack.SetReachRange(2);
            Roc_Beak_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            Roc_Beak_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            Roc_Beak_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(9);
            Roc_Beak_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);
        }

        public static void BuildNewRoc_Talons_Attack()
        {
             
            string text = "Roc_Talons_Attack";


            Roc_Talons_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_GiantEagle_Talons,          
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Roc_Talons_Attack.SetToHitBonus(13);
            Roc_Talons_Attack.SetReachRange(1); 
            Roc_Talons_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            Roc_Talons_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            Roc_Talons_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(9);
            Roc_Talons_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeSlashing);

 

            MotionForm motionForm = new MotionForm();
            motionForm.SetDistance(10);
            motionForm.SetType(MotionForm.MotionType.Levitate);

            EffectForm FallingEffect = new EffectForm();
            FallingEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            FallingEffect.SetLevelMultiplier(1);
            FallingEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            FallingEffect.SetCreatedByCondition(true);
            FallingEffect.FormType = EffectForm.EffectFormType.Motion;
            FallingEffect.SetMotionForm(motionForm);
            FallingEffect.SetHasSavingThrow(false);
            FallingEffect.SetCanSaveToCancel(false);
            FallingEffect.SetSaveOccurence(RuleDefinitions.TurnOccurenceType.StartOfTurn);

            Roc_Talons_Attack.EffectDescription.EffectForms.Add(FallingEffect);

            Roc_Talons_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(19);
            Roc_Talons_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Dexterity.Name);
        }

        public static void BuildNewIce_Bite_Attack()
        {
             
            string text = "Ice_Bite_Attack";


            Ice_Bite_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite,          
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Ice_Bite_Attack.SetReachRange(1);
            Ice_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);

            Ice_Bite_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(3);
            Ice_Bite_Attack.EffectDescription.EffectForms[1].DamageForm.SetDamageType(RuleDefinitions.DamageTypeCold);

            Ice_Bite_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_Orc_Grimblade_IceDagger.EffectDescription.EffectParticleParameters);
        }

        public static void BuildNewNagaSpit_Attack()
        {

            string text = "NagaSpit_Attack";


            NagaSpit_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Spider_Crimson_Spit,        
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            NagaSpit_Attack.SetToHitBonus(8);
            NagaSpit_Attack.EffectDescription.SetRangeParameter(6);
            NagaSpit_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(10);
            NagaSpit_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            NagaSpit_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePoison);
            NagaSpit_Attack.EffectDescription.EffectForms[0].SetHasSavingThrow(true);
            NagaSpit_Attack.EffectDescription.EffectForms[0].SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.HalfDamage);
            NagaSpit_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.Name);
            NagaSpit_Attack.EffectDescription.SetSavingThrowDifficultyAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.Name);
            NagaSpit_Attack.EffectDescription.SetHasSavingThrow(true);
            NagaSpit_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(15);


        }

        public static void BuildNewNagaBite_Attack()
        {

            string text = "NagaBite_Attack";


            NagaBite_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_PebbleThrow,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            NagaBite_Attack.SetToHitBonus(7);
            NagaBite_Attack.EffectDescription.SetRangeParameter(1);
            NagaBite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(1);
            NagaBite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            NagaBite_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(4);
            NagaBite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(10);
            damageForm.SetDieType(RuleDefinitions.DieType.D8);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypePoison);
            

            EffectForm extraDamageEffect = new EffectForm();
            extraDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraDamageEffect.SetLevelMultiplier(1);
            extraDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraDamageEffect.SetCreatedByCharacter(true);
            extraDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraDamageEffect.SetDamageForm(damageForm);
            extraDamageEffect.SetHasSavingThrow(true);
            extraDamageEffect.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.HalfDamage);

            NagaBite_Attack.EffectDescription.EffectForms.Add(extraDamageEffect);
            NagaBite_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.Name);
            NagaBite_Attack.EffectDescription.SetSavingThrowDifficultyAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.Name);
            NagaBite_Attack.EffectDescription.SetHasSavingThrow(true);
            NagaBite_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(15);


        }

        public static void BuildNewFork_Attack()
        {

            string text = "Fork_Attack";


            Fork_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Skeleton_Spear,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Fork_Attack.SetToHitBonus(10);
            Fork_Attack.SetReachRange(2);
            Fork_Attack.SetMaxRange(3);
            Fork_Attack.SetCloseRange(2);
            Fork_Attack.SetProximity(RuleDefinitions.AttackProximity.Melee);
            Fork_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            Fork_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            Fork_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(6);
            Fork_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);

        }

        public static void BuildNewHornedDevilTail_Attack()
        {

            string text = "HornedDevilTail_Attack";

            ConditionDefinition BleedingWound_Condition = BuildNewCondition(
                         "DH_Custom_" + text + "condition",                                                       
                         DatabaseHelper.ConditionDefinitions.ConditionBleeding,                                     
                         GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text + "condition").ToString(),  
                        "MonsterAttack/&DH_" + text + "condition" + "_Title",                                     
                         "MonsterAttack/&DH_" + text + "condition" + "_Description"                               
           );

            BleedingWound_Condition.SetAllowMultipleInstances(true);
            BleedingWound_Condition.RecurrentEffectForms[0].DamageForm.SetDiceNumber(3);
            BleedingWound_Condition.RecurrentEffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);


            HornedDevilTail_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Tail,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );


            ConditionForm TailCondition = new ConditionForm();
            TailCondition.SetApplyToSelf(false);
            TailCondition.SetForceOnSelf(false);
            TailCondition.Operation = ConditionForm.ConditionOperation.Add;
            TailCondition.SetConditionDefinitionName(BleedingWound_Condition.Name);
            TailCondition.ConditionDefinition = BleedingWound_Condition;

            EffectForm TailEffect = new EffectForm();
            TailEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            TailEffect.SetLevelMultiplier(1);
            TailEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            TailEffect.SetCreatedByCharacter(true);
            TailEffect.FormType = EffectForm.EffectFormType.Condition;
            TailEffect.ConditionForm = TailCondition;
            TailEffect.SetHasSavingThrow(true);
            TailEffect.SetCanSaveToCancel(true);
            TailEffect.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.Negates);

            
            HornedDevilTail_Attack.SetToHitBonus(10);
            HornedDevilTail_Attack.SetReachRange(2);
            HornedDevilTail_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            HornedDevilTail_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            HornedDevilTail_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(6);
            HornedDevilTail_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);

            HornedDevilTail_Attack.EffectDescription.EffectForms.Add(TailEffect);
            HornedDevilTail_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Wisdom.name);
            HornedDevilTail_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            HornedDevilTail_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(12);



        }

        public static void BuildNewPoisonLongsword_Attack()
        {

            string text = "PoisonLongsword_Attack";


            PoisonLongsword_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                           
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Veteran_Sorak_Agent_Longsword,  
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),      
                    "MonsterAttack/&DH_" + text + "_Title",                                         
                     "MonsterAttack/&DH_" + text + "_Description"                                   
                      );

            PoisonLongsword_Attack.SetToHitBonus(8); 
            PoisonLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(1);
            PoisonLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D10);
            PoisonLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(4);
            PoisonLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeSlashing);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(3);
            damageForm.SetDieType(RuleDefinitions.DieType.D8);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypePoison);

            EffectForm extraDamageEffect = new EffectForm();
            extraDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraDamageEffect.SetLevelMultiplier(1);
            extraDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraDamageEffect.SetCreatedByCharacter(true);
            extraDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraDamageEffect.SetDamageForm(damageForm);

            PoisonLongsword_Attack.EffectDescription.EffectForms.Add(extraDamageEffect);
            PoisonLongsword_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_PoisonousSnake_Bite.EffectDescription.EffectParticleParameters);

        }
        public static void BuildNewPoisonLongbow_Attack()
        {

            string text = "PoisonLongbow_Attack";


            PoisonLongbow_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_BadlandHunter_Longbow,      
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            PoisonLongbow_Attack.SetToHitBonus(7);
            PoisonLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(1);
            PoisonLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            PoisonLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(3);
            PoisonLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(3);
            damageForm.SetDieType(RuleDefinitions.DieType.D8);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypePoison);

            EffectForm extraDamageEffect = new EffectForm();
            extraDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraDamageEffect.SetLevelMultiplier(1);
            extraDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraDamageEffect.SetCreatedByCharacter(true);
            extraDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraDamageEffect.SetDamageForm(damageForm);

            ConditionForm PoisonLongbowCondition = new ConditionForm();
            PoisonLongbowCondition.SetApplyToSelf(false);
            PoisonLongbowCondition.SetForceOnSelf(false);
            PoisonLongbowCondition.Operation = ConditionForm.ConditionOperation.Add;
            PoisonLongbowCondition.SetConditionDefinitionName(DatabaseHelper.ConditionDefinitions.ConditionPoisoned.Name);
            PoisonLongbowCondition.ConditionDefinition = DatabaseHelper.ConditionDefinitions.ConditionPoisoned;

            EffectForm PoisonLongbowEffect = new EffectForm();
            PoisonLongbowEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            PoisonLongbowEffect.SetLevelMultiplier(1);
            PoisonLongbowEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            PoisonLongbowEffect.SetCreatedByCharacter(true);
            PoisonLongbowEffect.FormType = EffectForm.EffectFormType.Condition;
            PoisonLongbowEffect.ConditionForm = PoisonLongbowCondition;
            PoisonLongbowEffect.SetHasSavingThrow(true);
            PoisonLongbowEffect.SetCanSaveToCancel(false);
            PoisonLongbowEffect.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.Negates);


            PoisonLongbow_Attack.EffectDescription.EffectForms.Add(extraDamageEffect);
            PoisonLongbow_Attack.EffectDescription.EffectForms.Add(PoisonLongbowEffect);

            PoisonLongbow_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.name);
            PoisonLongbow_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            PoisonLongbow_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(14);
            PoisonLongbow_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_PoisonousSnake_Bite.EffectDescription.EffectParticleParameters);


        }

        public static void BuildNewRadiantLongsword_Attack()
        {

            string text = "RadiantLongsword_Attack";


            RadiantLongsword_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                           
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Hyeronimus_Greatsword,  
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),      
                    "MonsterAttack/&DH_" + text + "_Title",                                         
                     "MonsterAttack/&DH_" + text + "_Description"                                   
                      );

            RadiantLongsword_Attack.SetToHitBonus(15);
            RadiantLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            RadiantLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            RadiantLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            RadiantLongsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeSlashing);

            RadiantLongsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(6);
            RadiantLongsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetDieType(RuleDefinitions.DieType.D8);

            RadiantLongsword_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_Divine_Avatar.EffectDescription.EffectParticleParameters);

        }
        public static void BuildNewRadiantLongbow_Attack()
        {

            string text = "RadiantLongbow_Attack";


            RadiantLongbow_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_BadlandHunter_Longbow,      
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            RadiantLongbow_Attack.SetToHitBonus(13);
            RadiantLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            RadiantLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            RadiantLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            RadiantLongbow_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypePiercing);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(6);
            damageForm.SetDieType(RuleDefinitions.DieType.D8);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypeRadiant);

            EffectForm extraDamageEffect = new EffectForm();
            extraDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraDamageEffect.SetLevelMultiplier(1);
            extraDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraDamageEffect.SetCreatedByCharacter(true);
            extraDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraDamageEffect.SetDamageForm(damageForm);

            KillForm killForm = new KillForm();
            killForm.SetKillCondition(RuleDefinitions.KillCondition.UnderHitPoints);
            killForm.SetHitPoints(100);

            EffectForm killEffect = new EffectForm();
            killEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            killEffect.SetLevelMultiplier(1);
            killEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            killEffect.SetCreatedByCharacter(true);
            killEffect.FormType = EffectForm.EffectFormType.Kill;
            killEffect.SetKillForm(killForm);
            killEffect.SetHasSavingThrow(true);
            killEffect.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.Negates);

            RadiantLongbow_Attack.EffectDescription.EffectForms.Add(extraDamageEffect);

            RadiantLongbow_Attack.EffectDescription.EffectForms.Add(killEffect);

            RadiantLongbow_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.name);
            RadiantLongbow_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            RadiantLongbow_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(15);
            RadiantLongbow_Attack.EffectDescription.SetHasSavingThrow(true);
            RadiantLongbow_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_Divine_Avatar.EffectDescription.EffectParticleParameters);


        }

        public static void BuildNewAirBlast_Attack()
        {

            string text = "AirBlast_Attack";


            AirBlast_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_PebbleThrow,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            AirBlast_Attack.SetToHitBonus(7);
            AirBlast_Attack.EffectDescription.SetRangeParameter(24);
            AirBlast_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(5);
            AirBlast_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            AirBlast_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeThunder);

            MotionForm motion = new MotionForm(); 
            motion.SetDistance(2);
            motion.SetType(MotionForm.MotionType.PushFromOrigin);

            EffectForm motionEffect = new EffectForm();
            motionEffect.FormType = EffectForm.EffectFormType.Motion;
            motionEffect.SetMotionForm(motion); 
            motionEffect.SetApplyLevel(EffectForm.LevelApplianceType.No); 
            motionEffect.SetLevelType(RuleDefinitions.LevelSourceType.CharacterLevel);
            motionEffect.SetLevelMultiplier(1);

            AirBlast_Attack.EffectDescription.EffectForms.Add(motionEffect);

        }
        public static void BuildNewHurlFlame_Attack()
        {

            string text = "HurlFlame_Attack";


            HurlFlame_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Fire_Jester_Firebolt,       
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            HurlFlame_Attack.SetToHitBonus(7);
            HurlFlame_Attack.EffectDescription.SetRangeParameter(24);
            HurlFlame_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(5);
            HurlFlame_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            HurlFlame_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_FireOsprey_Touch.EffectDescription.EffectParticleParameters);

        }
        public static void BuildNewFireScimatar_Attack()
        {

            string text = "FireScimatar_Attack";


            FireScimatar_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_Cutthroat_Scimitar,  
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            FireScimatar_Attack.SetToHitBonus(10); 
            FireScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            FireScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(6);
            FireScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(2);
            damageForm.SetDieType(RuleDefinitions.DieType.D6);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypeFire);

            EffectForm extraFireDamageEffect = new EffectForm();
            extraFireDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraFireDamageEffect.SetLevelMultiplier(1);
            extraFireDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraFireDamageEffect.SetCreatedByCharacter(true);
            extraFireDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraFireDamageEffect.SetDamageForm(damageForm);

            FireScimatar_Attack.EffectDescription.EffectForms.Add(extraFireDamageEffect);
            FireScimatar_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_FireOsprey_Touch.EffectDescription.EffectParticleParameters);


        }
        public static void BuildNewLightningScimatar_Attack()
        {

            string text = "LightningScimatar_Attack";


            LightningScimatar_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_Cutthroat_Scimitar,  
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            LightningScimatar_Attack.SetToHitBonus(10); 
            LightningScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            LightningScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(6);
            LightningScimatar_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(2);
            damageForm.SetDieType(RuleDefinitions.DieType.D6);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypeLightning);

            EffectForm extraFireDamageEffect = new EffectForm();
            extraFireDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraFireDamageEffect.SetLevelMultiplier(1);
            extraFireDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraFireDamageEffect.SetCreatedByCharacter(true);
            extraFireDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraFireDamageEffect.SetDamageForm(damageForm);

            LightningScimatar_Attack.EffectDescription.EffectForms.Add(extraFireDamageEffect);
            LightningScimatar_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_ZealotShockingAntenna.EffectDescription.EffectParticleParameters);


        }

        public static void BuildNewGeneric_Bite_Attack()
        {
            // generic bite attack without extra damage for CR 10-15 monsters 
            string text = "Generic_Bite_Attack_No_ExtraDamage";


            Generic_Bite_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite,          
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Generic_Bite_Attack.SetReachRange(1);
            Generic_Bite_Attack.EffectDescription.EffectForms.RemoveAt(1);
            Generic_Bite_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_BrownBear_Bite.EffectDescription.EffectParticleParameters);

        }
        public static void BuildNewGeneric_Stronger_Bite_Attack()
        {

            // generic bite attack without extra damage for high level CR monsters 
            string text_1 = "Generic_Stronger_Bite_Attack_No_ExtraDamage";


            Generic_Stronger_Bite_Attack = BuildNewAttack(
                     "DH_Custom_" + text_1,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite,            
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text_1).ToString(),  
                    "MonsterAttack/&DH_" + text_1 + "_Title",                                     
                     "MonsterAttack/&DH_" + text_1 + "_Description"                               
                      );



            Generic_Stronger_Bite_Attack.SetToHitBonus(15);
            Generic_Stronger_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(5);
            Generic_Stronger_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D10);
            Generic_Stronger_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(5);
            Generic_Stronger_Bite_Attack.EffectDescription.EffectParticleParameters.Copy(DatabaseHelper.MonsterAttackDefinitions.Attack_BrownBear_Bite.EffectDescription.EffectParticleParameters);

            Generic_Stronger_Bite_Attack.EffectDescription.EffectForms.RemoveAt(1);
        }


        public static void BuildNewGeneric_Claw_Attack()
        {
            // correct dice numbers/type for ancient dragon claw
            string text = "Generic_Claw_Attack";


            AncientDragon_Claw_Attack = BuildNewAttack(
                        "DH_Custom_" + text,                                                       
                       DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Claw,           
                       GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),   
                      "MonsterAttack/&DH_" + text + "_Title",                                      
                       "MonsterAttack/&DH_" + text + "_Description"                                
                        );

            // generic ancient dragon Claw attack
            AncientDragon_Claw_Attack.SetToHitBonus(15);
            AncientDragon_Claw_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(3);
            AncientDragon_Claw_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            AncientDragon_Claw_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(9);



        }




        public static void BuildNew_AncientDragon_Bite_Attack()
        {




            Dictionary<string, int> dictionaryofAncientDragonBiteExtraDamageDiceNumbers = new Dictionary<string, int>();
            dictionaryofAncientDragonBiteExtraDamageDiceNumbers.Add("Ancient Black Dragon", 2);
            dictionaryofAncientDragonBiteExtraDamageDiceNumbers.Add("Ancient Blue Dragon", 2);
            dictionaryofAncientDragonBiteExtraDamageDiceNumbers.Add("Ancient Green Dragon", 3);
            dictionaryofAncientDragonBiteExtraDamageDiceNumbers.Add("Ancient Red Dragon", 4);
            dictionaryofAncientDragonBiteExtraDamageDiceNumbers.Add("Ancient White Dragon", 2);

            Dictionary<string, RuleDefinitions.DieType> dictionaryofAncientDragonBiteExtraDamageDiceType = new Dictionary<string, RuleDefinitions.DieType>();
            dictionaryofAncientDragonBiteExtraDamageDiceType.Add("Ancient Black Dragon", RuleDefinitions.DieType.D8);
            dictionaryofAncientDragonBiteExtraDamageDiceType.Add("Ancient Blue Dragon", RuleDefinitions.DieType.D10);
            dictionaryofAncientDragonBiteExtraDamageDiceType.Add("Ancient Green Dragon", RuleDefinitions.DieType.D6);
            dictionaryofAncientDragonBiteExtraDamageDiceType.Add("Ancient Red Dragon", RuleDefinitions.DieType.D6);
            dictionaryofAncientDragonBiteExtraDamageDiceType.Add("Ancient White Dragon", RuleDefinitions.DieType.D8);

            Dictionary<string, EffectParticleParameters> dictionaryofAncientDragonBiteEffectparticles = new Dictionary<string, EffectParticleParameters>();
            dictionaryofAncientDragonBiteEffectparticles.Add("Ancient Black Dragon", DatabaseHelper.MonsterAttackDefinitions.Attack_Black_Dragon_Bite.EffectDescription.EffectParticleParameters);
            dictionaryofAncientDragonBiteEffectparticles.Add("Ancient Blue Dragon", DatabaseHelper.MonsterAttackDefinitions.Attack_ZealotShockingAntenna.EffectDescription.EffectParticleParameters);
            dictionaryofAncientDragonBiteEffectparticles.Add("Ancient Green Dragon", DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite.EffectDescription.EffectParticleParameters);
            dictionaryofAncientDragonBiteEffectparticles.Add("Ancient Red Dragon", DatabaseHelper.MonsterAttackDefinitions.Attack_Fire_Elemental_Touch.EffectDescription.EffectParticleParameters);
            dictionaryofAncientDragonBiteEffectparticles.Add("Ancient White Dragon", DatabaseHelper.MonsterAttackDefinitions.Attack_Orc_Grimblade_IceDagger.EffectDescription.EffectParticleParameters);


            foreach (KeyValuePair<string, string> entry in NewMonsterAttributes.Dictionaryof_Dragon_DamageAffinity)
            {

                string text = entry.Value + "_Bite_Attack";
                text = text.Replace(" ", "");

                MonsterAttackDefinition Dragon_Bite_Attack = BuildNewAttack(
                       "DH_Custom_" + text,                                                       
                       DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite,          
                       GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                      "MonsterAttack/&DH_" + text + "_Title",                                     
                       "MonsterAttack/&DH_" + text + "_Description"                               
                        );

                Dragon_Bite_Attack.SetReachRange(3);
                Dragon_Bite_Attack.SetToHitBonus(15);
                Dragon_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
                Dragon_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D10);
                Dragon_Bite_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(9);

                // extra damage 
                Dragon_Bite_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(dictionaryofAncientDragonBiteExtraDamageDiceNumbers[entry.Key]);
                Dragon_Bite_Attack.EffectDescription.EffectForms[1].DamageForm.SetDieType(dictionaryofAncientDragonBiteExtraDamageDiceType[entry.Key]);
                Dragon_Bite_Attack.EffectDescription.EffectForms[1].DamageForm.SetDamageType(entry.Value);    // ListofDamageTypes_Dragon[i]);
                Dragon_Bite_Attack.EffectDescription.SetEffectParticleParameters(dictionaryofAncientDragonBiteEffectparticles[entry.Key]);


                DictionaryOfAncientDragonBites.Add(entry.Key, Dragon_Bite_Attack);


                DictionaryOfGenericBitesWithExtraDamage.Add(entry.Value, Dragon_Bite_Attack);



            }



        }






        public static void BuildNewAncientDragon_Tail_Attack()
        {
            // correct dice numbers/type for ancient dragon tail
            string text = "AncientDragon_Tail_Attack";


            AncientDragon_Tail_Attack = BuildNewAttack(
                        "DH_Custom_" + text,                                                       
                       DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Tail,           
                       GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),   
                      "MonsterAttack/&DH_" + text + "_Title",                                      
                       "MonsterAttack/&DH_" + text + "_Description"                                
                        );

            // generic ancient dragon Tail attack
            AncientDragon_Tail_Attack.SetReachRange(4);
            AncientDragon_Tail_Attack.SetToHitBonus(15);
            AncientDragon_Tail_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            AncientDragon_Tail_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            AncientDragon_Tail_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);



        }


        public static void BuildNewPitFiend_Bite_Attack()
        {
            string text = "PitFiend_Bite_Attack";

            ConditionDefinition PitFiend_Bite_Condition = BuildNewCondition(
                     "DH_Custom_" + text + "condition",                                                       
                     DatabaseHelper.ConditionDefinitions.ConditionPoisoned_BasicPoison,                       
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text + "condition").ToString(),  
                    "MonsterAttack/&DH_" + text + "condition" + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "condition" + "_Description"                               
                      );

            PitFiend_Bite_Condition.RecurrentEffectForms[0].DamageForm.SetDiceNumber(6);
            PitFiend_Bite_Condition.RecurrentEffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);


            PitFiend_Bite_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Green_Dragon_Bite,          
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            ConditionForm PitFiendBiteCondition = new ConditionForm();
            PitFiendBiteCondition.SetApplyToSelf(false);
            PitFiendBiteCondition.SetForceOnSelf(false);
            PitFiendBiteCondition.Operation = ConditionForm.ConditionOperation.Add;
            PitFiendBiteCondition.SetConditionDefinitionName(PitFiend_Bite_Condition.Name);
            PitFiendBiteCondition.ConditionDefinition = PitFiend_Bite_Condition;

            EffectForm PitFiendBiteEffect = new EffectForm();
            PitFiendBiteEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            PitFiendBiteEffect.SetLevelMultiplier(1);
            PitFiendBiteEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            PitFiendBiteEffect.SetCreatedByCharacter(true);
            PitFiendBiteEffect.FormType = EffectForm.EffectFormType.Condition;
            PitFiendBiteEffect.ConditionForm = PitFiendBiteCondition;
            PitFiendBiteEffect.SetHasSavingThrow(true);
            PitFiendBiteEffect.SetCanSaveToCancel(true);
            PitFiendBiteEffect.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.Negates);

            PitFiend_Bite_Attack.SetReachRange(2);
            PitFiend_Bite_Attack.EffectDescription.EffectForms.Add(PitFiendBiteEffect);
            PitFiend_Bite_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.name);
            PitFiend_Bite_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            PitFiend_Bite_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(21);

        }

 

        public static void BuildNew_PitFiend_Mace_Attack()
        {
            
            string text = "PitFiend_Mace_Attack";


            PitFiend_Mace_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Divine_Avatar,              
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );


            PitFiend_Mace_Attack.SetReachRange(2);
            PitFiend_Mace_Attack.SetToHitBonus(14);
            PitFiend_Mace_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            PitFiend_Mace_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            PitFiend_Mace_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);

            // extra damage 
            PitFiend_Mace_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(6);
            PitFiend_Mace_Attack.EffectDescription.EffectForms[1].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            PitFiend_Mace_Attack.EffectDescription.EffectForms[1].DamageForm.SetDamageType("DamageFire");    // ListofDamageTypes_Dragon[i]);


        }

        public static void BuildNewBalor_Longsword_Attack()
        {

            string text = "Balor_Longsword_Attack";


            Balor_Longsword_Attack = BuildNewAttack(
                 "DH_Custom_" + text,                                                       
                 DatabaseHelper.MonsterAttackDefinitions.Attack_Divine_Avatar,              
                 GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                "MonsterAttack/&DH_" + text + "_Title",                                     
                 "MonsterAttack/&DH_" + text + "_Description"                               
                  );

            Balor_Longsword_Attack.SetReachRange(2);
            Balor_Longsword_Attack.SetToHitBonus(14);
            Balor_Longsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(3);
            Balor_Longsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            Balor_Longsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            Balor_Longsword_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeSlashing);
    
    
            Balor_Longsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(3);
            Balor_Longsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetDieType(RuleDefinitions.DieType.D8);
            Balor_Longsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetBonusDamage(0);
            Balor_Longsword_Attack.EffectDescription.EffectForms[1].DamageForm.SetDamageType(RuleDefinitions.DamageTypeLightning);

            Balor_Longsword_Attack.SetItemDefinitionMainHand(DatabaseHelper.ItemDefinitions.Enchanted_Greataxe_Stormblade);
        }

        public static void BuildNewBalor_Whip_Attack()
        {

            string text = "Balor_Whip_Attack";


            Balor_Whip_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Divine_Avatar,              
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Balor_Whip_Attack.SetReachRange(6);
            Balor_Whip_Attack.SetMaxRange(6);
            Balor_Whip_Attack.SetToHitBonus(14);
            Balor_Whip_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(2);
            Balor_Whip_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            Balor_Whip_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            Balor_Whip_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeSlashing);
                  
            Balor_Whip_Attack.EffectDescription.EffectForms[1].DamageForm.SetDiceNumber(3);
            Balor_Whip_Attack.EffectDescription.EffectForms[1].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            Balor_Whip_Attack.EffectDescription.EffectForms[1].DamageForm.SetBonusDamage(0);
            Balor_Whip_Attack.EffectDescription.EffectForms[1].DamageForm.SetDamageType(RuleDefinitions.DamageTypeFire);
    
            MotionForm motionForm = new MotionForm();
            motionForm.SetDistance(5);
            motionForm.SetType(MotionForm.MotionType.DragToOrigin);
    
            EffectForm effectForm = new EffectForm();
            effectForm.SetApplyLevel(EffectForm.LevelApplianceType.No);
            effectForm.SetLevelMultiplier(1);
            effectForm.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            effectForm.SetCreatedByCharacter(true);
            effectForm.FormType = EffectForm.EffectFormType.Motion;
            effectForm.SetMotionForm(motionForm);
            effectForm.SetHasSavingThrow(true);
            effectForm.SetSavingThrowAffinity(RuleDefinitions.EffectSavingThrowType.Negates);
      
    
            Balor_Whip_Attack.EffectDescription.EffectForms.Add(effectForm);
            Balor_Whip_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Strength.Name);
            Balor_Whip_Attack.EffectDescription.SetHasSavingThrow(true);
            Balor_Whip_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            Balor_Whip_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(20);

        }



        public static void BuildNewLich_ParalyzingTouch_Attack()
        {
            string text = "Lich_ParalyzingTouch_Attack";



            Lich_ParalyzingTouch_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Ghost_Withering_Laethar,    
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            Lich_ParalyzingTouch_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(3);
            Lich_ParalyzingTouch_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            Lich_ParalyzingTouch_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(0);
            Lich_ParalyzingTouch_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeCold);


            Lich_ParalyzingTouch_Attack.SetToHitBonus(12);
            Lich_ParalyzingTouch_Attack.EffectDescription.EffectForms[1].ConditionForm.SetConditionDefinition (DatabaseHelper.ConditionDefinitions.ConditionParalyzed);
            Lich_ParalyzingTouch_Attack.EffectDescription.SetSavingThrowAbility(DatabaseHelper.SmartAttributeDefinitions.Constitution.name);
            Lich_ParalyzingTouch_Attack.EffectDescription.SetDifficultyClassComputation(RuleDefinitions.EffectDifficultyClassComputation.FixedValue);
            Lich_ParalyzingTouch_Attack.EffectDescription.SetFixedSavingThrowDifficultyClass(21);

        }


 

        public static void BuildNewFireTitan_Slam_Attack()
        {
            string text = "FireTitan_Slam_Attack";



            FireTitan_Slam_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Air_Elemental_Slam,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            FireTitan_Slam_Attack.SetToHitBonus(12);
            FireTitan_Slam_Attack.SetReachRange(3);
            FireTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(3);
            FireTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            FireTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(5);
            FireTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeBludgeoning);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(10);
            damageForm.SetDieType(RuleDefinitions.DieType.D6);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypeFire);

            EffectForm extraFireDamageEffect = new EffectForm();
            extraFireDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraFireDamageEffect.SetLevelMultiplier(1);
            extraFireDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraFireDamageEffect.SetCreatedByCharacter(true);
            extraFireDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraFireDamageEffect.SetDamageForm(damageForm);

            FireTitan_Slam_Attack.EffectDescription.EffectForms.Add(extraFireDamageEffect);

        }



        public static void BuildNewAirTitan_Slam_Attack()
        {
            string text = "AirTitan_Slam_Attack";



            AirTitan_Slam_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Air_Elemental_Slam,         
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            AirTitan_Slam_Attack.SetToHitBonus(16);
            AirTitan_Slam_Attack.SetReachRange(4);
            AirTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            AirTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D6);
            AirTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(6);
            AirTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeBludgeoning);

            DamageForm damageForm = new DamageForm();
            damageForm.SetDiceNumber(4);
            damageForm.SetDieType(RuleDefinitions.DieType.D6);
            damageForm.SetBonusDamage(0);
            damageForm.SetDamageType(RuleDefinitions.DamageTypeThunder);

            EffectForm extraDamageEffect = new EffectForm();
            extraDamageEffect.SetApplyLevel(EffectForm.LevelApplianceType.No);
            extraDamageEffect.SetLevelMultiplier(1);
            extraDamageEffect.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            extraDamageEffect.SetCreatedByCharacter(true);
            extraDamageEffect.FormType = EffectForm.EffectFormType.Damage;
            extraDamageEffect.SetDamageForm(damageForm);

            AirTitan_Slam_Attack.EffectDescription.EffectForms.Add(extraDamageEffect);

        }

 

        public static void BuildNewEarthTitan_Slam_Attack()
        {

            string text = "EarthTitan_Slam_Attack";


            EarthTitan_Slam_Attack = BuildNewAttack(
                         "DH_Custom_" + text,                                                       
                         DatabaseHelper.MonsterAttackDefinitions.Attack_Air_Elemental_Slam,         
                         GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                        "MonsterAttack/&DH_" + text + "_Title",                                     
                         "MonsterAttack/&DH_" + text + "_Description"                               
                          );

            EarthTitan_Slam_Attack.SetToHitBonus(16);
            EarthTitan_Slam_Attack.SetReachRange(4);
            EarthTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            EarthTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D10);
            EarthTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            EarthTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeBludgeoning);

              

            

        }
        public static void BuildNewConstructTitan_Slam_Attack()
        {

            string text = "ConstructTitan_Slam_Attack";


            ConstructTitan_Slam_Attack = BuildNewAttack(
                         "DH_Custom_" + text,                                                       
                         DatabaseHelper.MonsterAttackDefinitions.Attack_Air_Elemental_Slam,         
                         GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                        "MonsterAttack/&DH_" + text + "_Title",                                     
                         "MonsterAttack/&DH_" + text + "_Description"                               
                          );

            ConstructTitan_Slam_Attack.SetToHitBonus(18);
            ConstructTitan_Slam_Attack.SetReachRange(4);
            ConstructTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(3);
            ConstructTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D12);
            ConstructTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            ConstructTitan_Slam_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeBludgeoning);

            MotionForm motionForm = new MotionForm();
            motionForm.SetType(MotionForm.MotionType.PushFromOrigin);
            motionForm.SetDistance(4);

            EffectForm effectForm = new EffectForm();
            effectForm.SetApplyLevel(EffectForm.LevelApplianceType.No);
            effectForm.SetLevelMultiplier(1);
            effectForm.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            effectForm.SetCreatedByCharacter(true);
            effectForm.FormType = EffectForm.EffectFormType.Motion;
            effectForm.SetMotionForm(motionForm);

            ConstructTitan_Slam_Attack.EffectDescription.EffectForms.Add(effectForm);




        }

        public static void BuildNewConstructTitan_ForceCannon_Attack()
        {

            string text = "ConstructTitan_ForceCannon_Attack";


            ConstructTitan_ForceCannon_Attack = BuildNewAttack(
                         "DH_Custom_" + text,                                                       
                         DatabaseHelper.MonsterAttackDefinitions.Attack_Goblin_PebbleThrow,         
                         GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                        "MonsterAttack/&DH_" + text + "_Title",                                     
                         "MonsterAttack/&DH_" + text + "_Description"                               
                          );

            ConstructTitan_ForceCannon_Attack.SetToHitBonus(18);
            ConstructTitan_ForceCannon_Attack.SetReachRange(60);
            ConstructTitan_ForceCannon_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(4);
            ConstructTitan_ForceCannon_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D8);

            ConstructTitan_ForceCannon_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeForce);
/*
            ConstructTitan_ForceCannon_Attack.EffectDescription.SetEffectParticleParameters(DatabaseHelper.SpellDefinitions.MagicMissile.EffectDescription.EffectParticleParameters);

            MotionForm motionForm = new MotionForm();
            motionForm.SetType(MotionForm.MotionType.FallProne);
            motionForm.SetDistance(6);

            EffectForm effectForm = new EffectForm();
            effectForm.SetApplyLevel(EffectForm.LevelApplianceType.No);
            effectForm.SetLevelMultiplier(1);
            effectForm.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            effectForm.SetCreatedByCharacter(true);
            effectForm.FormType = EffectForm.EffectFormType.Motion;
            effectForm.SetMotionForm(motionForm);

            ConstructTitan_ForceCannon_Attack.EffectDescription.EffectForms.Add(effectForm);
*/



        }

 
        public static void BuildNewEarthTitan_Boulder_Attack()
        {
            string text = "EarthTitan_Boulder_Attack";


            EarthTitan_Boulder_Attack = BuildNewAttack(
                     "DH_Custom_" + text,                                                       
                     DatabaseHelper.MonsterAttackDefinitions.Attack_Giant_Fire_Rock,            
                     GuidHelper.Create(new System.Guid(Settings.GUID), "DH_Custom_" + text).ToString(),  
                    "MonsterAttack/&DH_" + text + "_Title",                                     
                     "MonsterAttack/&DH_" + text + "_Description"                               
                      );

            EarthTitan_Boulder_Attack.SetToHitBonus(6);
            EarthTitan_Boulder_Attack.SetReachRange(50);
            EarthTitan_Boulder_Attack.EffectDescription.EffectForms[0].DamageForm.SetDiceNumber(7);
            EarthTitan_Boulder_Attack.EffectDescription.EffectForms[0].DamageForm.SetDieType(RuleDefinitions.DieType.D10);
            EarthTitan_Boulder_Attack.EffectDescription.EffectForms[0].DamageForm.SetBonusDamage(8);
            EarthTitan_Boulder_Attack.EffectDescription.EffectForms[0].DamageForm.SetDamageType(RuleDefinitions.DamageTypeBludgeoning);

            EarthTitan_Boulder_Attack.SetItemDefinitionMainHand(null);

            MotionForm motionForm = new MotionForm();
            motionForm.SetType(MotionForm.MotionType.FallProne);
            motionForm.SetDistance(6);

            EffectForm effectForm = new EffectForm();
            effectForm.SetApplyLevel(EffectForm.LevelApplianceType.No);
            effectForm.SetLevelMultiplier(1);
            effectForm.SetLevelType(RuleDefinitions.LevelSourceType.ClassLevel);
            effectForm.SetCreatedByCharacter(true);
            effectForm.FormType = EffectForm.EffectFormType.Motion;
            effectForm.SetMotionForm(motionForm);

            EarthTitan_Boulder_Attack.EffectDescription.EffectForms.Add(effectForm);

        }

 

        //************************************************************************************************************************************
        //************************************************************************************************************************************
        public static MonsterAttackDefinition BuildNewAttack(string name, MonsterAttackDefinition baseAttack, string guid, string title, string description)
        {
            var unit = CopyAndCreateNewBlueprint<MonsterAttackDefinition>.CreateCopy(name,
                                                                             guid,
                                                                             title,
                                                                             description,
                                                                             baseAttack
                                                                             );
            return unit;
        }
        public static ConditionDefinition BuildNewCondition(string name, ConditionDefinition baseCondition, string guid, string title, string description)
        {
            var unit = CopyAndCreateNewBlueprint<ConditionDefinition>.CreateCopy(name,
                                                                             guid,
                                                                             title,
                                                                             description,
                                                                             baseCondition
                                                                             );
            return unit;
        }

    }

}
