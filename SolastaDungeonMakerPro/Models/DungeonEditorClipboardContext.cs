using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;
using SolastaModApi.Extensions;

namespace SolastaDungeonMakerPro.Models
{
    public static class DungeonEditorClipboardContext
    {
        public struct MyGadget
        {
            public string blueprintName;
            public int x;
            public int y;
            public LocationDefinitions.Orientation orientation;
        }

        public struct MyProp
        {
            public string blueprintName;
            public int x;
            public int y;
            public LocationDefinitions.Orientation orientation;
        }

        public struct MyRoom
        {
            public string blueprintName;
            public List<MyProp> myProps;
            public List<MyGadget> myGadgets;
        }

        internal static List<MyRoom> MyRooms => Main.Settings.MyRooms;

        internal static readonly List<RoomBlueprint> MyRoomBlueprints = new List<RoomBlueprint>();

        internal static void Init()
        {
            CreateClipboardCategory();

            foreach(var myRoom in MyRooms)
            {
                MyRoomBlueprints.Add(GetRoomBlueprint(myRoom));
            }
        }

        internal static void CreateClipboardCategory()
        {
            var dbBlueprintCategory = DatabaseRepository.GetDatabase<BlueprintCategory>();
            var emptyRoomsCategory = dbBlueprintCategory.GetElement("EmptyRooms");
            var clipboardCategory = Object.Instantiate(emptyRoomsCategory);

            clipboardCategory.name = "Zappaboard";
            clipboardCategory.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), clipboardCategory.name).ToString());
            clipboardCategory.GuiPresentation.Title = "Zappaboard";
            clipboardCategory.GuiPresentation.SetSortOrder(emptyRoomsCategory.GuiPresentation.SortOrder - 2);
            dbBlueprintCategory.Add(clipboardCategory);
        }

        internal static RoomBlueprint GetRoomBlueprint(MyRoom myRoom)
        {
            var gadgetDB = DatabaseRepository.GetDatabase<GadgetBlueprint>();
            var propDB = DatabaseRepository.GetDatabase<PropBlueprint>();
            var roomBlueprint = DatabaseRepository.GetDatabase<RoomBlueprint>().GetElement(myRoom.blueprintName);
            var myRoomBlueprint = Object.Instantiate(roomBlueprint);

            myRoomBlueprint.name = roomBlueprint.name + "Zappaboard" + System.DateTime.Now.ToFileTime();
            myRoomBlueprint.SetGuid(SolastaModApi.GuidHelper.Create(new System.Guid(Settings.GUID), roomBlueprint.name).ToString());
            myRoomBlueprint.SetCategory("Zappaboard");
            myRoomBlueprint.SetEmbeddedGadgets(new EmbeddedGadgetDescription[myRoom.myGadgets.Count]);
            myRoomBlueprint.SetEmbeddedProps(new EmbeddedPropDescription[myRoom.myProps.Count]);

            for (var i = 0; i < myRoom.myGadgets.Count; i++)
            {
                var myGadget = myRoom.myGadgets[i];
                var gadgetBlueprint = gadgetDB.GetElement(myGadget.blueprintName);

                myRoomBlueprint.EmbeddedGadgets[i] = new EmbeddedGadgetDescription();
                myRoomBlueprint.EmbeddedGadgets[i].SetGadgetBlueprint(gadgetBlueprint);
                myRoomBlueprint.EmbeddedGadgets[i].SetOrientation(myGadget.orientation);
                myRoomBlueprint.EmbeddedGadgets[i].SetPosition(new Vector2Int(myGadget.x, myGadget.y));
            }

            for (var i = 0; i < myRoom.myProps.Count; i++)
            {
                var myProp = myRoom.myProps[i];
                var propBlueprint = propDB.GetElement(myProp.blueprintName);

                myRoomBlueprint.EmbeddedProps[i] = new EmbeddedPropDescription();
                myRoomBlueprint.EmbeddedProps[i].SetPropBlueprint(propBlueprint);
                myRoomBlueprint.EmbeddedProps[i].SetOrientation(myProp.orientation);
                myRoomBlueprint.EmbeddedProps[i].SetPosition(new Vector2Int(myProp.x, myProp.y));
            }

            return myRoomBlueprint;
        }

        internal static void RefreshUI(UserLocationEditorScreen userLocationEditorScreen)
        {
            var roomBlueprintSelectionPanel = (RoomBlueprintSelectionPanel)AccessTools.Field(typeof(UserLocationEditorScreen), "roomBlueprintSelectionPanel").GetValue(userLocationEditorScreen);

            roomBlueprintSelectionPanel.Bind(userLocationEditorScreen.UserLocation.Environment, false);
        }

        internal static void AddRoom(UserLocationEditorScreen userLocationEditorScreen, UserRoom userRoom)
        {
            var angle = (int)userRoom.Orientation * 90f;
            
            userRoom.Rotate(-angle);
         
            var myRoom = new MyRoom()
            {
                blueprintName = userRoom.RoomBlueprint.name,
                myGadgets = new List<MyGadget>(),
                myProps = new List<MyProp>()
            };

            foreach (var userGadget in userRoom.UserGadgets)
            {
                var myGadget = new MyGadget()
                {
                    blueprintName = userGadget.GadgetBlueprint.name,
                    x = userGadget.Position.x,
                    y = userGadget.Position.y,
                    orientation = userGadget.Orientation,
                };

                myRoom.myGadgets.Add(myGadget);
            }

            foreach (var userProp in userRoom.UserProps)
            {
                var myProp = new MyProp()
                {
                    blueprintName = userProp.PropBlueprint.name,
                    x = userProp.Position.x,
                    y = userProp.Position.y,
                    orientation = userProp.Orientation
                };

                myRoom.myProps.Add(myProp);
            }

            MyRooms.Add(myRoom);
            MyRoomBlueprints.Add(GetRoomBlueprint(myRoom));

            RefreshUI(userLocationEditorScreen);

            userRoom.Rotate(angle);
        }

        internal static void RemoveRoom(UserLocationEditorScreen userLocationEditorScreen, RoomBlueprint roomBlueprint)
        {
            var index = MyRoomBlueprints.IndexOf(roomBlueprint);

            MyRooms.RemoveAt(index);
            MyRoomBlueprints.RemoveAt(index);

            RefreshUI(userLocationEditorScreen);
        }
    }
}