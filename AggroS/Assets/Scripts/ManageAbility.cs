using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class ManageAbility : MonoBehaviour
{
    public KeyCode key;
    public SOAbility Ability { get; private set; } = null;

    private int currentUseNumber;

    private float _timer = 0;

    public void Setup(SOAbility Ability)
    {
        this.Ability = Ability;
        currentUseNumber = Ability.use_number;
    }
     
    private void Update()
    {
        Timer();
        ManageInput();
    }
    private void Timer()
    {
        _timer += Time.deltaTime;
        if (_timer >= Ability.cooldown)
        {
            currentUseNumber++;
            _timer = 0;
        }
    }
    private void ManageInput()
    {
        if (Input.GetKeyDown(key) == false)
            return;

        if (currentUseNumber > 0)
        {
            currentUseNumber--;
            Ability.Use(Player.Instance.gameObject);
        }
        else
        {
            // todo: cant use it right now!
        }
    }
}
