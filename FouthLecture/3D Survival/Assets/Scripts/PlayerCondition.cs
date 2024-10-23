using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger { get { return uiCondition.hunger; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);
        
        if (hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue == 0f)
        {
            Die();
        }
    }

    private void Heal(float amout)
    {
        health.Add(amout);
    }

    private void Eat(float amout)
    {
        hunger.Add(amout);
    }

    private void Die()
    {
        Debug.Log("ав╬З╢ы..");
    }
}
