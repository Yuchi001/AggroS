using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SOScaleVariables scale;
    public Dictionary<EPlayerStats, int> PlayerStats_max { get; private set; } = new Dictionary<EPlayerStats, int>
    {
        { EPlayerStats.Cooldown_reduction, 0},
        { EPlayerStats.Magic_damage, 60},
        { EPlayerStats.Attack_damage, 55},
        { EPlayerStats.Health, 650},
        { EPlayerStats.Regeneration, 1},
        { EPlayerStats.Crit_chance, 0},
        { EPlayerStats.Movement_speed, 300}
    };
    public Dictionary<EPlayerStats, int> PlayerStats_current { get; private set; } = new Dictionary<EPlayerStats, int>()
    {
        { EPlayerStats.Cooldown_reduction, 0},
        { EPlayerStats.Magic_damage, 60},
        { EPlayerStats.Attack_damage, 55},
        { EPlayerStats.Health, 650},
        { EPlayerStats.Regeneration, 1},
        { EPlayerStats.Crit_chance, 0},
        { EPlayerStats.Movement_speed, 300}
    };
    public Dictionary<ESkillStats, int> PlayerSkills { get; private set; } = new Dictionary<ESkillStats, int>()
    {
        { ESkillStats.Magic, 0},
        { ESkillStats.Strenght, 0},
        { ESkillStats.Inteligence, 0},
        { ESkillStats.Constitution, 0},
        { ESkillStats.Dexternity, 0}
    };

    public int MagicDamage => PlayerStats_current[EPlayerStats.Magic_damage];
    public int AttackDamage => PlayerStats_current[EPlayerStats.Attack_damage];
    public int MovementSpeed => PlayerStats_current[EPlayerStats.Movement_speed];
    public int Health => PlayerStats_current[EPlayerStats.Health];
    public int Regeneration => PlayerStats_current[EPlayerStats.Regeneration];
    public int CooldownReduction => PlayerStats_current[EPlayerStats.Cooldown_reduction];
    public int CriticalChance => PlayerStats_current[EPlayerStats.Crit_chance];

    public static Player Instance { get; private set; }

    public SOWeaponItem WeaponSlot { get; private set; }

    private void Awake()
    {
        if (Instance != this && Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && WeaponSlot != null)
        {
            WeaponSlot.UseWeapon(this);
        }
    }

    public void EquipWeapon(SOWeaponItem weapon)
    {
        WeaponSlot = weapon;
    }

    public void AddPoint(ESkillStats stat)
    {
        PlayerSkills[stat]++;
        var upStats = scale.ScaleStats.Where(s => s.skill == stat).FirstOrDefault();
        foreach(var pair in upStats.SkillValuePair)
        {
            if (pair.stat == EPlayerStats.None)
                continue;
            PlayerStats_max[pair.stat] += pair.value;
        }
    }
    public void AddPoint(int stat_int)
    {
        if (stat_int == 0)
            return;

        var stat = (ESkillStats)stat_int;
        PlayerSkills[stat]++;
        var upStats = scale.ScaleStats.Where(s => s.skill == stat).FirstOrDefault();
        foreach (var pair in upStats.SkillValuePair)
        {
            PlayerStats_max[pair.stat] += pair.value;
            PlayerStats_current[pair.stat] += pair.value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemObj item) == false)
            return;

        EquipWeapon(item.item as SOWeaponItem);
        Destroy(collision.gameObject);
    }
}