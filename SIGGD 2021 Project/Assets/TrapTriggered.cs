using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggered : Trigger
{
    private bool isTriggered;

    public override bool isActive()
    {
        return isTriggered;
    }

    public void setTrigger(bool b)
    {
        isTriggered = b;
    }

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;    
    }
}
