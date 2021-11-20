using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLow : Trigger
{
    [SerializeField] private Health characterHealth;
    [SerializeField] private int healthBreakpoint;

    public override bool isActive()
    {
        if (characterHealth.GetCurrHealth() <= healthBreakpoint)
        {
            return true;
        }

        return false;
    }
}
