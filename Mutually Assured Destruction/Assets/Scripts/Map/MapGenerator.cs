using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Map currentMap;
    [HideInInspector] Map currentMapCheck;
    public Texture2D terrainMap;


    private void OnValidate()
    {
        if (currentMap != currentMapCheck)
        {
            currentMapCheck = currentMap;

            if (currentMap == null)
            {
                terrainMap = null;
            }
            else
            {
                terrainMap = currentMap.terrainMap;
            }
        }
    }
}