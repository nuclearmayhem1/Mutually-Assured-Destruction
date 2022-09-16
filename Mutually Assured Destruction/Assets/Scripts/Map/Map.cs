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
public class Nation
{
    public Color color;
    public int ID;
    public string name;
    public string leaderTitle;
    public List<Character> characters;
    public int territoryArea;
    public Rect bounds;

    public Nation(Color color = default, int iD = -1, string name = "", string leaderTitle = "", List<Character> characters = null, int territoryArea = 0, Rect bounds = default)
    {
        this.color = color;
        this.ID = iD;
        this.name = name;
        this.leaderTitle = leaderTitle;
        this.characters = characters;
        this.territoryArea = territoryArea;
        this.bounds = bounds;
    }

    public Nation Clone()
    {
        return new Nation(color, ID, name, leaderTitle, characters, territoryArea, bounds);
    }
}
