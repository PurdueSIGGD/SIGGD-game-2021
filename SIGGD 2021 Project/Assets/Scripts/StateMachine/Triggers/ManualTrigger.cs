using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTrigger : Trigger
{
    private bool triggered = false;

    public override bool isActive()
    {
        if (triggered)
        {
            triggered = false;
            return true;
        }
        return false;
    }

    public void setTrigger()
    {
        triggered = true;
    }
}
