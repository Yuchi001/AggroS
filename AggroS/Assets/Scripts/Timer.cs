using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Action action = null;
    private float maxTime = 0;
    private float timer = 0;

    private bool initialized = false;
    public void Setup(float time, Action action)
    {
        maxTime = time;
        this.action = action;
        initialized = true;
    }
    void Update()
    {
        if (initialized == false)
            return;

        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            action?.Invoke();
            Destroy(gameObject);
        }
    }
}
