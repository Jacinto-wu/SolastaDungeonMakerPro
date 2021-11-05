using System.Collections.Generic;
using UnityEngine;
using ModKit;
using SolastaModApi.Extensions;

namespace SolastaDungeonMakerPro.Models
{
    internal static class DungeonEditorContext
    {
        internal enum ExtendedDungeonSize
        {
            First = 3,
            Small3X = 3,
            Small4X = 4,
            Small5X = 5,
            Large3X = 6,
            Large4X = 7,
            Large5X = 8,
            Last = 8
        }

        internal static Dictionary<UserLocationDefinitions.Size, int> customDungeonSizes = new Dictionary<UserLocationDefinitions.Size, int>() 
        {
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Small3X, 150 },
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Small4X, 200 },
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Small5X, 250 },
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Large3X, 300 },
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Large4X, 400 },
            { (UserLocationDefinitions.Size) ExtendedDungeonSize.Large5X, 500 },
        };

        internal static readonly List<string> OutdoorRooms = new List<string>();

        internal static void UpdateAvailableDungeonSizes()
        {
            if (Main.Settings.EnableCustomDungeonSizes)
            {
                UserLocationDefinitions.CellsBySize[UserLocationDefinitions.Size.Medium] = 75;

                foreach (var kvp in customDungeonSizes)
                {
                    UserLocationDefinitions.CellsBySize.Add(kvp.Key, kvp.Value);
                }
            }
        }

        internal static void LoadFlatRooms()
        {
            if (Main.Settings.EnableFlatRooms)
            {
                Models.DungeonEditorContext.CreateFlatRooms(12);
                Models.DungeonEditorContext.CreateSpecialFlatRoom("Drain_Big_24C_A", 12 + 1);
                Models.DungeonEditorContext.CreateSpecialFlatRoom("Drain_Big_24C_B", 12 + 2);
            }
        }

        internal static void CreateFlatRooms(int maxMultiplier)
        {
            var template = "Crossroad_12C";
            var dbRoomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>();

            for (var multiplier = 1; multiplier <= maxMultiplier; multiplier++)
            {
                var flatRoom = Object.Instantiate(dbRoomBlueprint.GetElement(template));

                flatRoom.name = $"Flat{multiplier:D2}Room";
                flatRoom.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), flatRoom.name).ToString());
                flatRoom.GuiPresentation.Title = "Flat".red() + " Room";
                flatRoom.GuiPresentation.SetSortOrder(multiplier);
                flatRoom.GuiPresentation.SetHidden(true);
                flatRoom.SetCategory("FlatRooms");
                flatRoom.SetDimensions(new Vector2Int(flatRoom.Dimensions.x * multiplier, flatRoom.Dimensions.y * multiplier));
                flatRoom.SetCellInfos(new int[flatRoom.Dimensions.x * flatRoom.Dimensions.y]);
                flatRoom.wallSpriteReference = new UnityEngine.AddressableAssets.AssetReferenceSprite("");
                flatRoom.wallAndOpeningSpriteReference = new UnityEngine.AddressableAssets.AssetReferenceSprite("");

                for (var i = 0; i < flatRoom.CellInfos.Length; i++)
                {
                    flatRoom.CellInfos[i] = 1;
                }

                dbRoomBlueprint.Add(flatRoom);
            }
        }

        internal static void CreateSpecialFlatRoom(string template, int sortOrder)
        {
            var dbRoomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>();
            var flatRoom = Object.Instantiate(dbRoomBlueprint.GetElement(template));

            flatRoom.name = "Flat" + template;
            flatRoom.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), flatRoom.name).ToString());
            flatRoom.GuiPresentation.Title = "Flat".red() + " " + Gui.Format(flatRoom.GuiPresentation.Title);
            flatRoom.GuiPresentation.SetSortOrder(sortOrder);
            flatRoom.GuiPresentation.SetHidden(true);
            flatRoom.SetCategory("FlatRooms");
            for (var i = 0; i < flatRoom.CellInfos.Length; i++)
            {
                if (flatRoom.CellInfos[i] == 2 || flatRoom.CellInfos[i] == 3)
                {
                    flatRoom.CellInfos[i] = 1;
                }
            }

            dbRoomBlueprint.Add(flatRoom);
        }

        internal static void UpdateCategories()
        {
            var categories = new List<BlueprintCategory>();
            var dbBlueprintCategory = DatabaseRepository.GetDatabase<BlueprintCategory>();
            var dbEnvironmentDefinition = DatabaseRepository.GetDatabase<EnvironmentDefinition>();
            var emptyRoomsCategory = dbBlueprintCategory.GetElement("EmptyRooms");
            var flatRoomsCategory = Object.Instantiate(emptyRoomsCategory);

            flatRoomsCategory.name = "FlatRooms";
            flatRoomsCategory.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), flatRoomsCategory.name).ToString());
            flatRoomsCategory.GuiPresentation.Title = Gui.Format($"BlueprintCategory/&{flatRoomsCategory.name}Title").red();
            flatRoomsCategory.GuiPresentation.SetSortOrder(emptyRoomsCategory.GuiPresentation.SortOrder + 1);
            dbBlueprintCategory.Add(flatRoomsCategory);

            foreach (var blueprintCategory in dbBlueprintCategory.GetAllElements())
            {
                foreach (var environmentDefinition in dbEnvironmentDefinition.GetAllElements())
                {
                    var newBlueprintCategory = Object.Instantiate(blueprintCategory);
                    var environmentName = environmentDefinition.Name;
                    var categoryName = blueprintCategory.Name + "~" + environmentName + "~MOD";

                    newBlueprintCategory.name = categoryName;
                    newBlueprintCategory.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), newBlueprintCategory.name).ToString());
                    newBlueprintCategory.GuiPresentation.Title = Gui.Format(blueprintCategory.GuiPresentation.Title) + " " + Gui.Format(environmentDefinition.GuiPresentation.Title) + " [MODDED]".red();
                    categories.Add(newBlueprintCategory);
                }
            }

            foreach (var category in categories)
            {
                dbBlueprintCategory.Add(category);
            }
        }

        internal static void UpdateGadgetsPlacement()
        {
            if (Main.Settings.FlexibleGadgetsPlacement)
            {
                var dbGadgetBlueprint = DatabaseRepository.GetDatabase<GadgetBlueprint>();

                foreach (var gadgetBlueprint in dbGadgetBlueprint.GetAllElements())
                {
                    if (gadgetBlueprint.GroundPlacement || gadgetBlueprint.GroundLowPlacement || gadgetBlueprint.GroundHighPlacement ||
                        gadgetBlueprint.OpeningPlacement || gadgetBlueprint.OpeningLowPlacement || gadgetBlueprint.OpeningHighPlacement)
                    {
                        gadgetBlueprint.SetGroundPlacement(true);
                        gadgetBlueprint.SetGroundLowPlacement(true);
                        gadgetBlueprint.SetGroundHighPlacement(true);
                        gadgetBlueprint.SetOpeningPlacement(true);
                        gadgetBlueprint.SetOpeningLowPlacement(true);
                        gadgetBlueprint.SetOpeningHighPlacement(true);
                    }
                }
            }
        }

        internal static void UpdatePropsPlacement()
        {
            if (Main.Settings.FlexiblePropsPlacement)
            {
                var dbPropBlueprint = DatabaseRepository.GetDatabase<PropBlueprint>();

                foreach (var propBlueprint in dbPropBlueprint.GetAllElements())
                {
                    if (propBlueprint.GroundPlacement || propBlueprint.GroundLowPlacement || propBlueprint.GroundHighPlacement ||
                        propBlueprint.OpeningPlacement || propBlueprint.OpeningLowPlacement || propBlueprint.OpeningHighPlacement)
                    {
                        propBlueprint.SetGroundPlacement(true);
                        propBlueprint.SetGroundLowPlacement(true);
                        propBlueprint.SetGroundHighPlacement(true);
                        propBlueprint.SetOpeningPlacement(true);
                        propBlueprint.SetOpeningLowPlacement(true);
                        propBlueprint.SetOpeningHighPlacement(true);
                    }
                }
            }
        }

        internal static void UnleashGadgetsOnAllEnvironments()
        {
            var dbGadgetBlueprint = DatabaseRepository.GetDatabase<GadgetBlueprint>();
            var dbEnvironmentDefinition = DatabaseRepository.GetDatabase<EnvironmentDefinition>();
            var newProps = new List<GadgetBlueprint>();

            foreach (var gadgetBlueprint in dbGadgetBlueprint.GetAllElements())
            {
                foreach (var prefabByEnvironment in gadgetBlueprint.PrefabsByEnvironment)
                {
                    var environmentName = prefabByEnvironment.Environment;

                    if (environmentName != string.Empty)
                    {
                        var prefabEnvironmentDefinition = dbEnvironmentDefinition.GetElement(environmentName);
                        var newGadgetBlueprint = Object.Instantiate(gadgetBlueprint);
                        var categoryName = gadgetBlueprint.Category + "~" + environmentName + "~MOD";

                        newGadgetBlueprint.name = gadgetBlueprint.Name + "~" + environmentName + "~MOD";
                        newGadgetBlueprint.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), newGadgetBlueprint.name).ToString());
                        newGadgetBlueprint.GuiPresentation.Title = Gui.Format(gadgetBlueprint.GuiPresentation.Title) + " " + Gui.Format(prefabEnvironmentDefinition.GuiPresentation.Title).red();
                        newGadgetBlueprint.SetCategory(categoryName);
                        newGadgetBlueprint.PrefabsByEnvironment.Clear();

                        foreach (var environmentDefinition in dbEnvironmentDefinition.GetAllElements())
                        {
                            var myPrefabByEnvironment = new BaseBlueprint.PrefabByEnvironmentDescription();

                            myPrefabByEnvironment.SetEnvironment(environmentDefinition.name);
                            myPrefabByEnvironment.SetPrefabReference(prefabByEnvironment.PrefabReference);

                            newGadgetBlueprint.PrefabsByEnvironment.Add(myPrefabByEnvironment);
                        }

                        newProps.Add(newGadgetBlueprint);
                    }
                }
            }

            foreach (var newProp in newProps)
            {
                dbGadgetBlueprint.Add(newProp);
            }

            SetModdedGadgetsHiddenStatus(!Main.Settings.EnableModdedGadgets);
        }

        internal static void UnleashPropsOnAllEnvironments()
        {
            var dbPropBlueprint = DatabaseRepository.GetDatabase<PropBlueprint>();
            var dbEnvironmentDefinition = DatabaseRepository.GetDatabase<EnvironmentDefinition>();
            var newProps = new List<PropBlueprint>();

            foreach (var propBlueprint in dbPropBlueprint.GetAllElements())
            {
                foreach (var prefabByEnvironment in propBlueprint.PrefabsByEnvironment)
                {
                    var environmentName = prefabByEnvironment.Environment;

                    if (environmentName != string.Empty)
                    {
                        var prefabEnvironmentDefinition = dbEnvironmentDefinition.GetElement(environmentName);
                        var newPropBlueprint = Object.Instantiate(propBlueprint);
                        var categoryName = propBlueprint.Category + "~" + environmentName + "~MOD";

                        newPropBlueprint.name = propBlueprint.Name + "~" + environmentName + "~MOD";
                        newPropBlueprint.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), newPropBlueprint.name).ToString());
                        newPropBlueprint.GuiPresentation.Title = Gui.Format(propBlueprint.GuiPresentation.Title) + " " + Gui.Format(prefabEnvironmentDefinition.GuiPresentation.Title).red();
                        newPropBlueprint.SetCategory(categoryName);
                        newPropBlueprint.PrefabsByEnvironment.Clear();

                        foreach (var environmentDefinition in dbEnvironmentDefinition.GetAllElements())
                        {
                            var myPrefabByEnvironment = new BaseBlueprint.PrefabByEnvironmentDescription();

                            myPrefabByEnvironment.SetEnvironment(environmentDefinition.name);
                            myPrefabByEnvironment.SetPrefabReference(prefabByEnvironment.PrefabReference);

                            newPropBlueprint.PrefabsByEnvironment.Add(myPrefabByEnvironment);
                        }

                        newProps.Add(newPropBlueprint);
                    }
                }
            }

            foreach (var newProp in newProps)
            {
                dbPropBlueprint.Add(newProp);
            }

            SetModdedPropsHiddenStatus(!Main.Settings.EnableModdedProps);
        }

        internal static void UnleashRoomsOnAllEnvironments()
        {
            var dbRoomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>();
            var dbEnvironmentDefinition = DatabaseRepository.GetDatabase<EnvironmentDefinition>();
            var newRooms = new List<RoomBlueprint>();

            foreach (var roomBlueprint in dbRoomBlueprint.GetAllElements())  
            {
                if (roomBlueprint.Category == "EmptyRooms" || roomBlueprint.Category == "FlatRooms")
                {   
                    foreach (var prefabByEnvironment in roomBlueprint.PrefabsByEnvironment)
                    {
                        var environmentName = prefabByEnvironment.Environment;

                        if (environmentName != string.Empty)
                        {
                            var prefabEnvironmentDefinition = dbEnvironmentDefinition.GetElement(environmentName);
                            var newRoomBlueprint = Object.Instantiate(roomBlueprint);
                            var categoryName = roomBlueprint.Category + "~" + environmentName + "~MOD";

                            if (prefabEnvironmentDefinition.Outdoor)
                            {
                                OutdoorRooms.Add(roomBlueprint.Name);
                            }

                            newRoomBlueprint.name = roomBlueprint.Name + "~" + environmentName + "~MOD";
                            newRoomBlueprint.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), newRoomBlueprint.name).ToString());
                            newRoomBlueprint.GuiPresentation.Title = Gui.Format(roomBlueprint.GuiPresentation.Title) + " " + Gui.Format(prefabEnvironmentDefinition.GuiPresentation.Title).red();
                            newRoomBlueprint.SetCategory(categoryName);
                            newRoomBlueprint.GuiPresentation.SetHidden(false);
                            newRoomBlueprint.PrefabsByEnvironment.Clear();

                            foreach (var environmentDefinition in dbEnvironmentDefinition.GetAllElements())
                            {
                                if (!prefabEnvironmentDefinition.Outdoor || environmentDefinition.Outdoor)
                                {
                                    var myPrefabByEnvironment = new BaseBlueprint.PrefabByEnvironmentDescription();

                                    myPrefabByEnvironment.SetEnvironment(environmentDefinition.name);
                                    myPrefabByEnvironment.SetPrefabReference(prefabByEnvironment.PrefabReference);

                                    newRoomBlueprint.PrefabsByEnvironment.Add(myPrefabByEnvironment);
                                }
                            }

                            newRooms.Add(newRoomBlueprint);

                            if (prefabEnvironmentDefinition.Outdoor)
                            {
                                OutdoorRooms.Add(newRoomBlueprint.Name);
                            }
                        }
                    }
                }
            }

            foreach(var newRoom in newRooms)
            {
                dbRoomBlueprint.Add(newRoom);
            }

            Models.DungeonEditorContext.SetModdedRoomsHiddenStatus(!Main.Settings.EnableModdedRooms);
        }

        internal static void SetModdedGadgetsHiddenStatus(bool hidden)
        {
            var dbGadgetBlueprint = DatabaseRepository.GetDatabase<GadgetBlueprint>();

            foreach (var gadgetBlueprint in dbGadgetBlueprint.GetAllElements())
            {
                if (gadgetBlueprint.Name.EndsWith("MOD"))
                {
                    gadgetBlueprint.GuiPresentation.SetHidden(hidden);
                }
            }
        }

        internal static void SetModdedPropsHiddenStatus(bool hidden)
        {
            var dbPropBlueprint = DatabaseRepository.GetDatabase<PropBlueprint>();

            foreach (var propBlueprint in dbPropBlueprint.GetAllElements())
            {
                if (propBlueprint.Name.EndsWith("MOD"))
                {
                    propBlueprint.GuiPresentation.SetHidden(hidden);
                }
            }

        }
        
        internal static void SetModdedRoomsHiddenStatus(bool hidden) 
        {
            var dbRoomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>();

            foreach (var roomBlueprint in dbRoomBlueprint.GetAllElements())
            {
                if (roomBlueprint.Name.EndsWith("MOD"))
                {
                    roomBlueprint.GuiPresentation.SetHidden(hidden);
                }
            }
        }
    }
}