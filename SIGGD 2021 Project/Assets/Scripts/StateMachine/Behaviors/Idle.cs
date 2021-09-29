using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Behavior
{
    public override void run()
    {
        //does nothing b/c idle
    }

    public override void OnBehaviorEnter()
    {
        //called when this behavior becomes active
        //might set some variable values here
    }

    public override void OnBehaviorExit()
    {
        //called when this behavior becomes inactive 
        //might reset variable values here
    }
}
