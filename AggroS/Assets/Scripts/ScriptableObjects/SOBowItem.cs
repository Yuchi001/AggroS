using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Bow", fileName = "newBow")]
public class SOBowItem : SOWeaponItem
{
    public GameObject arrow;
    public float range;
    public float speed;
    public override DMG UseWeapon(Player player)
    {
        var dmg = base.UseWeapon(player);
        Instantiate(
            arrow, 
            player.
            transform.position, 
            Quaternion.LookRotation(player.transform.forward))
            .GetComponent<Arrow>().Setup(dmg.ad, range, speed);
        return dmg;
    }
}
