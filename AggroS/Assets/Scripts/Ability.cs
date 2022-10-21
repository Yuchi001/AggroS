using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected Player player_script;
    protected Transform player_transform;
    protected GameObject player_go;

    protected GameObject ability_prefab;

    public virtual void Setup(GameObject player, GameObject ability_prefab)
    {
        player_script = player.GetComponent<Player>();
        player_transform = player.transform;
        player_go = player;
        transform.position = player_transform.position;

        this.ability_prefab = ability_prefab;
    }
}
