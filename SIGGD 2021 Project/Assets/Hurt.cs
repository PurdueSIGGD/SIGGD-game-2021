using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : Trigger
{
    [SerializeField] private Health characterHealth;
    private int lastHealth = 0;

    public override bool isActive()
    {
        if (characterHealth.GetCurrHealth() < lastHealth)
        {
            return true;
        }

        return false;
    }

    public void MarkHealth()
    {
        lastHealth = characterHealth.GetCurrHealth();
    }
}