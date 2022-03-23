using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLow : Trigger
{
    [SerializeField] private Health characterHealth;
    [SerializeField] private int[] healthBreakpoints;
    private int breakpointCount = 0;

    public override bool isActive()
    {
        if (breakpointCount < healthBreakpoints.Length && characterHealth.GetCurrHealth() <= healthBreakpoints[breakpointCount])
        {
            breakpointCount++;
            return true;
        }

        return false;
    }
}
