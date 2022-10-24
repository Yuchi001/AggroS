using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SOWeaponItem : SOItem
{
    public EWeapon weapon_type;
    public SOAbility ability;
    public float attack_frequency;
    [Range(1, 100)] public int attackDmg_scaler = 100;
    [Range(1, 100)] public int magicDmg_scaler = 100;
    [Range(1, 100)] public int critDmg_scaler = 100;

    public virtual DMG UseWeapon(Player player)
    {
        if (player == null)
            return new DMG(0,0,0);

        DMG dmg;
        dmg.ad = (int)(player.AttackDamage * (((float)attackDmg_scaler) / 100));
        dmg.ap = (int)(player.AttackDamage * (((float)attackDmg_scaler) / 100));
        dmg.crit = (int)(player.AttackDamage * (((float)attackDmg_scaler) / 100));
        return dmg;
    }
}

public struct DMG
{
    public int ad;
    public int ap;
    public int crit;

    public DMG(int ad, int ap, int crit)
    {
        this.ad = ad;
        this.ap = ap;
        this.crit = crit;
    }
}