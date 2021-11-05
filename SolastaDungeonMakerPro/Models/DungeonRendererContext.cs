using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using AwesomeTechnologies;
using AwesomeTechnologies.VegetationSystem;
using AwesomeTechnologies.VegetationSystem.Biomes;
using HarmonyLib;

namespace SolastaDungeonMakerPro.Models
{  
    internal static class DungeonRendererContext
    {
        const int MARGIN = 25;
        const int FLAT_ROOM_SIZE = 12;
        const string FLAT_ROOM_TAG = "Flat";

        private static VegetationMaskArea templateVegetationMaskArea = null;

        private static bool IsFlatRoom(UserRoom userRoom) => userRoom.RoomBlueprint.name.StartsWith(FLAT_ROOM_TAG);

        private static bool IsDynamicFlatRoom(UserRoom userRoom) => IsFlatRoom(userRoom) && int.TryParse(userRoom.RoomBlueprint.name.Substring(FLAT_ROOM_TAG.Length, 2), out int _);

        public static void GetTemplateVegetationMaskArea(WorldLocation worldLocation)
        {
            var prefabByReference = (Dictionary<AssetReference, GameObject>)AccessTools.Field(worldLocation.GetType(), "prefabByReference").GetValue(worldLocation);

            foreach (var prefab in prefabByReference.Values)
            {
                templateVegetationMaskArea = prefab.GetComponentInChildren<VegetationMaskArea>();

                if (templateVegetationMaskArea != null)
                {
                    break;
                }
            }
        }

        public static void SetupLocationTerrain(WorldLocation worldLocation, UserLocation userLocation)
        {
            var masterTerrain = worldLocation.gameObject.GetComponentInChildren<Terrain>();

            if (masterTerrain != null)
            {
                // calculates inverted heights in map coordinates
                var locationSize = UserLocationDefinitions.CellsBySize[userLocation.Size];
                var mapHeights = new int[locationSize + MARGIN * 2, locationSize + MARGIN * 2];

                foreach (var userRoom in userLocation.UserRooms)
                {
                    var isIndoor = !Models.DungeonEditorContext.OutdoorRooms.Contains(userRoom.RoomBlueprint.name);
                    int border = 2;

                    int px = userRoom.Position.x;
                    int py = userRoom.Position.y;
                    int oh = userRoom.OrientedHeight;
                    int ow = userRoom.OrientedWidth;

                    for (var x = 0; x < ow; x++)
                    {
                        for (var y = 0; y < oh; y++)
                        {
                            var lowGround = isIndoor && (x >= border && x <= ow - border && y >= border && y <= oh - border || userRoom.GetCellType(x, y) == RoomBlueprint.CellType.GroundLow);

                            mapHeights[MARGIN + px + x, MARGIN + py + y] = lowGround ? 1 : 0;
                        }
                    }
                }

                // calculates heights in terrain data coordinates
                int resolution = masterTerrain.terrainData.heightmapResolution;
                float[,] heights = new float[resolution, resolution];

                for (int y = 0; y < resolution; y++)
                {
                    for (int x = 0; x < resolution; x++)
                    {
                        int sx = (int)System.Math.Round(x * (locationSize + MARGIN * 2f - 1f) / (resolution - 1f));
                        int sy = (int)System.Math.Round(y * (locationSize + MARGIN * 2f - 1f) / (resolution - 1f));

                        heights[y, x] = 1 - mapHeights[sx, sy];
                    }
                }

                // adjusts terrain to new settings
                masterTerrain.terrainData = TerrainDataCloner.Clone(masterTerrain.terrainData);
                masterTerrain.terrainData.size = new Vector3(locationSize + MARGIN * 2f, 5f, locationSize + MARGIN * 2f);
                masterTerrain.terrainData.SetHeights(0, 0, heights);
                masterTerrain.transform.position = new Vector3(masterTerrain.transform.position.x, -5.01f, masterTerrain.transform.position.z);

                ((List<TerrainData>)AccessTools.Field(worldLocation.GetType(), "duplicatedTerrainData").GetValue(worldLocation)).Add(masterTerrain.terrainData);

                // updates the biome to cover the entire location
                var biomeMaskArea = worldLocation.gameObject.GetComponentInChildren<BiomeMaskArea>();

                if (biomeMaskArea != null)
                {
                    biomeMaskArea.ClearNodes();
                    biomeMaskArea.AddNode(biomeMaskArea.transform.InverseTransformDirection(new Vector3(-MARGIN, 0, locationSize + MARGIN)));
                    biomeMaskArea.AddNode(biomeMaskArea.transform.InverseTransformDirection(new Vector3(-MARGIN, 0, -MARGIN)));
                    biomeMaskArea.AddNode(biomeMaskArea.transform.InverseTransformDirection(new Vector3(locationSize + MARGIN, 0, -MARGIN)));
                    biomeMaskArea.AddNode(biomeMaskArea.transform.InverseTransformDirection(new Vector3(locationSize + MARGIN, 0, locationSize + MARGIN)));
                    biomeMaskArea.UpdateBiomeMask();

                    worldLocation.gameObject.GetComponentInChildren<VegetationSystemPro>()?.CalculateVegetationSystemBounds();
                }
            }
        }

        public static void SetupFlatRooms(Transform roomTransform, UserRoom userRoom)
        {
            void DisableWalls(Transform transform)
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    DisableWalls(transform.GetChild(i));
                }

                var name = transform.gameObject.name;

                if ((name.Contains("Wall") && !name.Contains("Drain")) || name.Contains("Column") || name.Contains("DM_Dirt_Pack"))
                {
                    // need to keep parents around otherwise pure flat locations don't render correctly
                    if (transform.childCount > 0)
                    {
                        transform.position = new Vector3(-1f, 0f, -1f);
                    }
                    else
                    {
                        transform.gameObject.SetActive(false);
                    }
                }
            }

            if (IsFlatRoom(userRoom))
            {
                DisableWalls(roomTransform);

                if (int.TryParse(userRoom.RoomBlueprint.name.Substring(FLAT_ROOM_TAG.Length, 2), out int multiplier))
                {
                    var rnd = new System.Random();

                    roomTransform.position = new Vector3(roomTransform.position.x - (multiplier - 1) * FLAT_ROOM_SIZE / 2, 0, roomTransform.position.z - (multiplier - 1) * FLAT_ROOM_SIZE / 2);

                    for (var x = 0; x < multiplier; x++)
                    {
                        for (var z = 0; z < multiplier; z++)
                        {
                            if (x > 0 || z > 0)
                            {
                                var angle = LocationDefinitions.OrientationToAngle((LocationDefinitions.Orientation)rnd.Next(0, 3));
                                var newRoom = Object.Instantiate(roomTransform.gameObject, new Vector3(roomTransform.position.x + FLAT_ROOM_SIZE * x, 0, roomTransform.position.z + FLAT_ROOM_SIZE * z), Quaternion.identity, roomTransform.parent);

                                newRoom.transform.rotation = Quaternion.Euler(0, angle, 0);
                            }
                        }
                    }

                    // adds a hint to fix the reflection probe later on
                    roomTransform.name = FLAT_ROOM_TAG + roomTransform.name;
                }
            }
        }

        public static void AddVegetationMaskArea(Transform roomTransform, UserRoom userRoom)
        {
            if (templateVegetationMaskArea != null && !Models.DungeonEditorContext.OutdoorRooms.Contains(userRoom.RoomBlueprint.name))
            {
                var vegetationMaskArea = Object.Instantiate<VegetationMaskArea>(templateVegetationMaskArea, roomTransform);

                float sizex = userRoom.OrientedWidth;
                float sizey = userRoom.OrientedHeight;

                // exceptional case here as the mask must be a contanst size in this case as the vegetation mask object will get re-instantiated later
                if (IsDynamicFlatRoom(userRoom))
                {
                    sizex = FLAT_ROOM_SIZE;
                    sizey = FLAT_ROOM_SIZE;
                }

                vegetationMaskArea.transform.position = new Vector3(userRoom.Position.x + sizex / 2f, 0, userRoom.Position.y + sizey / 2f);
                vegetationMaskArea.AdditionalGrassPerimiter = 0;
                vegetationMaskArea.RemoveGrass = true;
                vegetationMaskArea.RemoveLargeObjects = true;
                vegetationMaskArea.RemoveObjects = true;
                vegetationMaskArea.RemovePlants = true;
                vegetationMaskArea.RemoveTrees = true;
                vegetationMaskArea.ClearNodes();
                vegetationMaskArea.AddNode(new Vector3(-sizex / 2f, 0, -sizey / 2f));
                vegetationMaskArea.AddNode(new Vector3(-sizex / 2f, 0, +sizey / 2f));
                vegetationMaskArea.AddNode(new Vector3(+sizex / 2f, 0, +sizey / 2f));
                vegetationMaskArea.AddNode(new Vector3(+sizex / 2f, 0, -sizey / 2f));
                vegetationMaskArea.UpdateVegetationMask();
            }
        }

        public static void FixFlatRoomReflectionProbe(WorldLocation worldLocation)
        {
            var reflectionProbes = worldLocation.GetComponentsInChildren<ReflectionProbe>();

            foreach (var reflectionProbe in reflectionProbes)
            {
                if (reflectionProbe.transform.parent.name.StartsWith(FLAT_ROOM_TAG))
                {
                    reflectionProbe.transform.position = new Vector3(reflectionProbe.size.x / 2f, reflectionProbe.size.y, reflectionProbe.size.z / 2f);
                }
            }
        }
    }
}