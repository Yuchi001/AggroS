using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public object props = null;
    public SOItem item;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = item.item_sprite_ui;
    }
}
