using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public KeyCode GetKeyBind_Ability(EAbilityPlace place)
    {
        return KeyCode.None;
    }
}
