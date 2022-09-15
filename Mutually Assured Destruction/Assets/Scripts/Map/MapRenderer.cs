using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public SpriteRenderer screen;
    public GameMap map;
    public Texture2D displayMap;
    private MapMode lastMode;
    public MapMode mapMode;
    public Sprite mapSprite;

    private void OnValidate()
    {
        if (mapSprite == null || displayMap == null && map.terrainMap != null)
        {
            displayMap = new Texture2D(map.terrainMap.width, map.terrainMap.height);
            displayMap.name = "Display map";
            displayMap.filterMode = FilterMode.Point;
            mapSprite = Sprite.Create(displayMap, new Rect(0, 0, map.terrainMap.width, map.terrainMap.height), Vector2.one / 2);
            mapSprite.name = "Display sprite";
            screen.sprite = mapSprite;
        }
        if (mapMode != lastMode)
        {
            if (map.waterMap != null && map.nationMap != null)
            {
                Color[] colorPixels = map.waterMap.GetPixels();
                Color[] nationPixels = map.nationMap.GetPixels();

                for (int i = 0; i < nationPixels.Length; i++)
                {
                    colorPixels[i] += nationPixels[i];
                };
                displayMap.SetPixels(colorPixels);
                displayMap.Apply();
            }
            lastMode = mapMode;
        }
    }

}

public enum MapMode
{
    none, normal
}

[System.Serializable]
public struct GameMap
{
    public Texture2D terrainMap;
    public Texture2D nationMap;
    public Texture2D waterMap;
}