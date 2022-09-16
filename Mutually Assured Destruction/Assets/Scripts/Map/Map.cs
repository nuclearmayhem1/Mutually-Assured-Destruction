using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "GameAssets/Map", order = 1)]
public class Map : ScriptableObject
{
    public Texture2D terrainMap;
    public Texture2D nationMap;
    public Texture2D waterMap;
    public List<Nation> nations;
}

[System.Serializable]
public struct Nation
{
    public Color color;
    public int ID;
    public string name;
    public string LeaderTitle;
    public List<Character> characters;
    public int territoryArea;
    public Rect bounds;
}
