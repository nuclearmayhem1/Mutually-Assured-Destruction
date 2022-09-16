using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameManager gameManager;
    public MapRenderer mapRenderer;
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
        mapRenderer.map = map;

    }

    public void ReadNationMap()
    {
        nations = new List<Nation>();
        Color32[] nationPixels = nationMap.GetPixels32();
        Color lastColor = Color.black;
        int lastNation = -1;
        List<int> nationAreias = new List<int>();

        for (int i = 0; i < nationPixels.Length; i++)
        {
            if (nationPixels[i] == lastColor)
            {
                if (lastNation != -1)
                {
                    nationAreias[lastNation]++;
                }
            }
            else
            {
                if (nationPixels[i] != Color.black)
                {
                    for (int x = 0; x < nations.Count; x++)
                    {
                        if (nations[x].color == nationPixels[i])
                        {
                            nationAreias[x]++;
                            lastNation = nations[x].ID;
                            goto end;
                        }
                    }
                    Nation newNation = new Nation();
                    newNation.name = "Nation " + nations.Count;
                    newNation.ID = nations.Count;
                    newNation.color = nationPixels[i];
                    nations.Add(newNation);
                    lastNation = newNation.ID;
                    nationAreias.Add(1);
                    end:;
                    lastColor = nationPixels[i];
                }
                else
                {
                    lastColor = nationPixels[i];
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
            Rect bounds = new Rect(-1, -1, -1, -1);

            for (int y = 0; y < nationPixels.Length; y++)
            {
                if (nationPixels[y] == nationF.color)
                {
                    Vector2 pos = IndexToVector(y, nationMap.width);
                    if (pos.x < bounds.x || bounds.x == -1)
                    {
                        bounds.x = pos.x;
                    }
                    else if (pos.x > bounds.width || bounds.width == -1)
                    {
                        bounds.width = pos.x - bounds.x;
                    }

                    if (pos.y < bounds.y || bounds.y == -1)
                    {
                        bounds.y = pos.y;
                    }
                    else if (pos.y > bounds.height || bounds.height == -1)
                    {
                        bounds.height = pos.y - bounds.y;
                    }
                }
            }
            nationF.bounds = bounds;
            nations[i] = nationF;
        }
    }

    public static Vector2Int IndexToVector(int index, int width)
    {
        int x = index % width;
        int y = Mathf.FloorToInt(index / width);

        return new Vector2Int(x, y);
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