using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public MapRenderer mapeRenderer;
    public Map currentMap;
    [HideInInspector] Map currentMapCheck;
    public Texture2D terrainMap;
    public Texture2D nationMap;
    public Texture2D waterMap;
    [HideInInspector]public int sizePower;

    public List<Nation> nations = new List<Nation>();

    [Range(0, 5)] public int extraWidth = 2;

    public void ResizeMaps()
    {
        
    }

    public void SaveMap()
    {
        currentMap.terrainMap = terrainMap;
        currentMap.nationMap = nationMap;
        currentMap.waterMap = waterMap;

        currentMap.nations = new List<Nation>();
        currentMap.nations.AddRange(nations);
    }

    public void ApplyMap()
    {
        gameManager.nations = new List<Nation>();
        gameManager.nations.AddRange(nations);
        GameMap map = new GameMap();
        map.terrainMap = terrainMap;
        map.nationMap = nationMap;
        map.waterMap = waterMap;
        mapeRenderer.map = map;
    }

    public void ReadNationMap()
    {
        nations = new List<Nation>();
        Color32[] nationPixels = nationMap.GetPixels32();
        Color lastColor = Color.black;
        int lastNation = -1;
        List<int> nationAreias = new List<int>();

        foreach (Color pixel in nationPixels)
        {
            if (pixel == lastColor)
            {
                if (lastNation != -1)
                {
                    nationAreias[lastNation]++;
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
                            nationAreias[i]++;
                            lastNation = nations[i].ID;
                            goto end;
                        }
                    }
                    Nation newNation = new Nation();
                    newNation.name = "Nation " + nations.Count;
                    newNation.ID = nations.Count;
                    newNation.color = pixel;
                    nations.Add(newNation);
                    lastNation = newNation.ID;
                    nationAreias.Add(1);
                    end:;
                    lastColor = pixel;
                }
                else
                {
                    lastColor = pixel;
                    lastNation = -1;
                }
            }
        }

        for (int i = 0; i < nations.Count; i++)
        {
            int areia = nations[i].territoryArea + nationAreias[i];
            Nation nationF = new Nation();
            nationF.name = nations[i].name;
            nationF.ID = nations[i].ID;
            nationF.color = nations[i].color;
            nationF.territoryArea = areia;
            nations[i] = nationF;
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

                nations = null;
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