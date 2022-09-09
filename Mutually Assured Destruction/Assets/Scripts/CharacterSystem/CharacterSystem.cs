using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : MonoBehaviour
{



}

[System.Serializable]
public struct Character
{
    public string name;
    public Sprite portrait;

    public JobPosition job;
    [Range(0,1)] public float skill;
}

public enum JobPosition
{
    Civilian, DefenseMinister, FinacialMinister, Leader, ForignAffairsMinister, Diplomat
}