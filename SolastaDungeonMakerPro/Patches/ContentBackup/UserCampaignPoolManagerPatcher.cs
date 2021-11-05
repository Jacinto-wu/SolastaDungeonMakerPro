using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches
{
    internal static class UserCampaignPoolManagerPatcher
    {
        // this patch allows the last X campaign files to be backed up in the mod folder
        [HarmonyPatch(typeof(UserCampaignPoolManager), "SaveUserCampaign")]
        internal static class UserCampaignPoolManager_SaveUserCampaign_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var deleteMethod = typeof(File).GetMethod("Delete");
                var backupAndDeleteMethod = typeof(Models.ContentBackupContext).GetMethod("BackupAndDelete");

                foreach (var instruction in instructions)
                {
                    if (instruction.Calls(deleteMethod))
                    {
                        yield return new CodeInstruction(OpCodes.Ldarg_1);
                        yield return new CodeInstruction(OpCodes.Call, backupAndDeleteMethod);
                    }
                    else
                    {
                        yield return instruction;
                    }
                }
            }
        }
    }
}
