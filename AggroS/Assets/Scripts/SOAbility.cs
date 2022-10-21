using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Ability", fileName = "newAbility")]
public class SOAbility : ScriptableObject
{
    public string display_name = "none";
    [Tooltip("In seconds"), Min(0.1f)] public float cooldown = 1f;
    [Min(1)] public int use_number = 1;
    public EAbilityKey key = EAbilityKey.None;
    public GameObject ability_object;

    public void Use(GameObject player)
    {
        var ability = Instantiate(ability_object).GetComponent<Ability>();
        ability.Setup(player, ability_object);
    }
}
