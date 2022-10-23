using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dictionary<EPlayerStats, int> PlayerStats_max { get; private set; } = new Dictionary<EPlayerStats, int>();
    public Dictionary<EPlayerStats, int> PlayerStats_current { get; private set; } = new Dictionary<EPlayerStats, int>();
    public Dictionary<ESkillStats, int> PlayerSkills { get; private set; } = new Dictionary<ESkillStats, int>();

    public static Player Instance { get; private set; }

    public float MovementSpeed { get; private set; } = 2;

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void AddPoint(ESkillStats stat, int points = 1)
    {
        switch(stat)
        {
            case ESkillStats.Constitution:
                PlayerStats_max[EPlayerStats.Health] += 200;
                break;
            case ESkillStats.Strenght:
                break;
            case ESkillStats.Magic:
                break;
            case ESkillStats.Inteligence:
                break;
            case ESkillStats.Dexternity:
                break;
        }
    }
}