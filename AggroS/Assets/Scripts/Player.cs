using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SOScaleVariables scale;
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

    }

    public void EquipWeapon(SOWeaponItem weapon)
    {
        WeaponSlot = weapon;
    }

    public void AddPoint(ESkillStats stat)
    {

    }
    public void AddPoint(int stat_int)
    {
        if (stat_int == 0)
            return;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ItemObj item) == false)
            return;

        EquipWeapon(item.item as SOWeaponItem);
        Destroy(collision.gameObject);
    }
}

public class PlayerStats
{

}