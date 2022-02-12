using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTriggered : Trigger
{
    [SerializeField] private ApproachTrap approachTrap;
    private bool isTriggered;

    public override bool isActive()
    {
        if (isTriggered)
        {
            isTriggered = false;
            return true;
        }
        return false;
    } // basic trigger check. To see how this trigger is set to true see Trap

    public void setTrigger(bool b)
    {
        isTriggered = b;
    }

    public ApproachTrap getBehavior()
    {
        return approachTrap;
    } // This is here so the Trap script can access the behavior from this trigger

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;    
    }
}
