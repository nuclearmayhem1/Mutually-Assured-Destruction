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
    //Identity
    public Color color;
    public int ID;
    public string name;
    public string leaderTitle;
    public Rect bounds;
    public Sprite flag;

    //State
    public List<float> relations;
    public List<int> rivals;
    public List<int> friends;
    public List<int> enemies;
    public List<int> allies;
    public List<Character> characters;
    public int territoryArea;
    public float wealth;
    public float population;
    public float power;
    public float trust;

    //Personality
    public float aggresiveness;
    public float stability;
    public float security;
    public float people;
    public float greed;

    public Nation(Color color = default, int iD = -1, string name = "", string leaderTitle = "", List<Character> characters = null, int territoryArea = 0, Rect bounds = default , List<float> relations = default,
        Sprite flag = default, float wealth = default, float population = default, float power = default, float trust = default, float aggresiveness = default, float stability = default,
        float security = default, float people = default, float greed = default)
    {
        this.color = color;
        this.ID = iD;
        this.name = name;
        this.leaderTitle = leaderTitle;
        this.characters = characters;
        this.territoryArea = territoryArea;
        this.bounds = bounds;
        this.relations = relations;
        this.flag = flag;
        this.wealth = wealth;
        this.population = population;
        this.power = power;
        this.trust = trust;
        this.aggresiveness = aggresiveness;
        this.stability = stability;
        this.security = security;
        this.people = people;
        this.greed = greed;
    }

    public Nation Clone()
    {
        return new Nation(color, ID, name, leaderTitle, characters, territoryArea, bounds, relations);
    }
}
