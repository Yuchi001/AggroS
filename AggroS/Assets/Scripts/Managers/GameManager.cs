using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private Transform ParentTimers => transform.Find("timers");
    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public KeyCode GetKeyBind_Ability(EAbilityKey place)
    {
        return KeyCode.None;
    }

    public void Timer(float time, System.Action action)
    {
        var timer = Instantiate(new GameObject($"Timer#{System.DateTime.Now.Ticks}"), ParentTimers);
        timer.AddComponent<Timer>().Setup(time, action);
    }
}
