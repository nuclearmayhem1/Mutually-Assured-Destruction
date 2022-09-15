using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Map currentMap;
    [HideInInspector] Map currentMapCheck;
    public Texture2D terrainMap;
    public Texture2D nationMap;
    public Texture2D waterMap;
    public Vector2Int mapSize;

    public List<Nation> nations = new List<Nation>();

    public void ResizeMaps()
    {
        terrainMap.Reinitialize(mapSize.x, mapSize.y);
        nationMap.Reinitialize(mapSize.x, mapSize.y);
    }

    public void ReadNationMap()
    {
        nations = new List<Nation>();
        Color32[] nationPixels = nationMap.GetPixels32();
        Color lastColor = Color.black;
        Nation lastNation = null;

        foreach (Color pixel in nationPixels)
        {
            if (pixel == lastColor)
            {
                if (lastNation != null)
                {
                    lastNation.territoryArea++;
                }
            }
            else
            {
                if (pixel != Color.black)
                {
                    for (int i = 0; i < nations.Count; i++)
                    {
                        if (nations[i].color == pixel)
                        {
                            nations[i].territoryArea++;
                            lastNation = nations[i];
                            goto end;
                        }
                    }
                    Nation newNation = new Nation();
                    newNation.name = "Nation " + nations.Count;
                    newNation.ID = nations.Count;
                    newNation.color = pixel;
                    nations.Add(newNation);
                    lastNation = newNation;
                    end:;
                    lastColor = pixel;
                }
                else
                {
                    lastColor = pixel;
                    lastNation = null;
                }
            }
        }

    }

    private void OnValidate()
    {
        if (currentMap != currentMapCheck)
        {
            currentMapCheck = currentMap;

            if (currentMap == null)
            {
                terrainMap = null;
                nationMap = null;
                waterMap = null;

                nations = new List<Nation>();
            }
            else
            {
                terrainMap = currentMap.terrainMap;
                nationMap = currentMap.nationMap;
                waterMap = currentMap.waterMap;
                nations = currentMap.nations;
            }
        }
    }
}