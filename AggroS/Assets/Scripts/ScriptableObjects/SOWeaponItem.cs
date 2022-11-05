using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Weapon", fileName = "MyNewWeapon")]
public class SOWeaponItem : SORequirementItem
{
    public EWeapon weapon_type;
    public ERarity rarity;
    public Vector2Int damageRange;
    public Animation firstAbilityAnim;
    public Animation secondAbilityAnim;
    public SOAbility ability_LMB;
    public SOAbility ability_RMB;
}