//using System;
//using System.Collections.Generic;
//using System.Reflection.Emit;
//using System.Text.RegularExpressions;
//using HarmonyLib;
//using UnityEngine;

//namespace TA
//{
//    [Serializable]
//    public class ModCampaign : UserCampaign
//    {
//        [SerializeField]
//        private List<ModMonster> modMonsters = new List<ModMonster>();

//        public List<ModMonster> ModMonsters => modMonsters;

//        public static ModCampaign Clone(UserCampaign userCampaign)
//        {
//            ModCampaign modCampaign = new ModCampaign();
//            modCampaign.CopyContent((UserContent)userCampaign);
//            modCampaign.startLevelMin = userCampaign.startLevelMin;
//            modCampaign.startLevelMax = userCampaign.startLevelMax;
//            modCampaign.environment = userCampaign.environment;
//            modCampaign.FirstTimeSettings = userCampaign.FirstTimeSettings;
//            foreach (UserLocation userLocation in userCampaign.userLocations)
//                modCampaign.userLocations.Add(userLocation.Clone());
//            foreach (UserItem userItem in userCampaign.userItems)
//                modCampaign.userItems.Add(userItem.Clone());
//            foreach (UserMonster userMonster in userCampaign.userMonsters)
//            {
//                modCampaign.userMonsters.Add((ModMonster)userMonster.Clone());
//                modCampaign.modMonsters.Add((ModMonster)userMonster.Clone());
//            }
//            foreach (UserNpc userNpc in userCampaign.userNpcs)
//                modCampaign.userNpcs.Add(userNpc.Clone());
//            foreach (UserMerchantInventory merchantInventory in userCampaign.userMerchantInventories)
//                modCampaign.userMerchantInventories.Add(merchantInventory.Clone());
//            return modCampaign;
//        }
//    }

//    [Serializable]
//    public class ModMonster: UserMonster
//    {
//        [SerializeField]
//        private float challengeRating;

//        [UserContentTextField("ChallengeRating", CanOverride = true, SortOrder = 14)]
//        public float ChallengeRating
//        {
//            get => this.challengeRating;
//            set => this.challengeRating = value;
//        }
//    }
//}

//namespace SolastaDungeonMakerPro.Models
//{


//    public static class UserContentExtendedContext
//    {
//        public static string MyToJson(UserCampaign userCampaign)
//        {
//            var modCampaign = TA.ModCampaign.Clone(userCampaign);
//            var json = JsonUtility.ToJson(modCampaign);

//            return json;
//        }
//    }

//    [HarmonyPatch(typeof(UserMonster), "CreateUserMonster")]
//    internal static class UserMonster_CreateUserMonster_Patch
//    {
//        internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
//        {
//            var found = false;
//            var modMonsterConstructor = typeof(TA.ModMonster).GetConstructor(new Type[] { });

//            foreach (var instruction in instructions)
//            {
//                if (instruction.opcode == OpCodes.Newobj && !found)
//                {
//                    found = true;
//                    yield return new CodeInstruction(OpCodes.Newobj, modMonsterConstructor);
//                }
//                else
//                {
//                    yield return instruction;
//                }
//            }
//        }

//        internal static void Postfix(UserMonster __result)
//        {
//            ((TA.ModMonster)__result).ChallengeRating = __result.ReferenceMonsterDefinition.ChallengeRating;
//        }
//    }

//    [HarmonyPatch(typeof(UserMonster), "Clone")]
//    internal static class UserMonster_Clone_Patch
//    {
//        internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
//        {
//            var found = false;
//            var modMonsterConstructor = typeof(TA.ModMonster).GetConstructor(new Type[] { });

//            foreach (var instruction in instructions)
//            {
//                if (instruction.opcode == OpCodes.Newobj && !found)
//                {
//                    found = true;
//                    yield return new CodeInstruction(OpCodes.Newobj, modMonsterConstructor);
//                }
//                else
//                {
//                    yield return instruction;
//                }
//            }
//        }

//        internal static void Postfix(UserMonster __instance, UserMonster __result)
//        {
//            ((TA.ModMonster)__result).ChallengeRating = ((TA.ModMonster)__instance).ChallengeRating;
//        }
//    }

//    [HarmonyPatch(typeof(UserCampaignPoolManager), "SaveUserCampaign")]
//    public static class UserCampaignPoolManager_SaveUserCampaign_Patch
//    {


//        internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
//        {
//            var toJsonMethod = typeof(JsonUtility).GetMethod("ToJson", new Type[] { typeof(object) });
//            var myToJsonMethod = typeof(UserContentExtendedContext).GetMethod("MyToJson");

//            foreach (var instruction in instructions)
//            {
//                if (instruction.Calls(toJsonMethod))
//                {
//                    yield return new CodeInstruction(OpCodes.Call, myToJsonMethod);
//                }
//                else
//                {
//                    yield return instruction;
//                }
//            }
//        }
//    }

//    //[HarmonyPatch(typeof(UserCampaignPoolManager), "ReadCampaignFromDisk")]
//    //internal static class UserCampaignPoolManager_ReadCampaignFromDisk_Patch
//    //{
//    //    internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
//    //    {
//    //        var postLoadJson = typeof(UserCampaign).GetMethod("PostLoadJson");
//    //        var mypostLoadJson = typeof(ModCampaign).GetMethod("MyPostLoadJson");

//    //        foreach (var instruction in instructions)
//    //        {
//    //            if (instruction.Calls(postLoadJson))
//    //            {
//    //                yield return new CodeInstruction(OpCodes.Call, mypostLoadJson);
//    //            }
//    //            else
//    //            {
//    //                yield return instruction;
//    //            }
//    //        }
//    //    }
//    //}
//}