using HarmonyLib;

namespace SolastaDungeonMakerPro.Patches.DungeonEditor
{ 
   internal static class BaseBlueprintPatcher
    {
        // ensures custom props display the proper icon
        [HarmonyPatch(typeof(BaseBlueprint), "GetAssetKey")]
        internal static class BaseBlueprint_GetAssetKey_Patch
        {
            internal static bool Prefix(
                BaseBlueprint __instance,
                ref string __result,
                BaseBlueprint.PrefabByEnvironmentDescription prefabByEnvironmentDescription,
                EnvironmentDefinition environmentDefinition,
                bool perspective)
            {
                if (!Main.Settings.EnableModdedProps)
                    return true;

                if (!(__instance is PropBlueprint propBlueprint))
                    return true;

                if (!propBlueprint.Name.EndsWith("MOD"))
                    return true;

                var a = propBlueprint.Name.Split(new [] { '~' }, 3);

                if (a.Length == 3)
                {
                    var propName = a[0];
                    var environmentName = a[1];

                    string str1 = "Gui/Bitmaps/Blueprints/Props/";
                    string str2 = "User_Props_" + propName;
                    if ((BaseDefinition)environmentDefinition != (BaseDefinition)null && prefabByEnvironmentDescription.Environment == environmentDefinition.Name)
                    {
                        str1 = str1 + environmentName + "/";
                        str2 = str2 + "_" + environmentName;
                    }
                    __result = str1 + str2 + (perspective ? "_Pers" : "_Top");
                }

                return false;
            }
        }
    }
}