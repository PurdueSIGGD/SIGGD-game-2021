using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTime : Trigger
{
    public float timeToWait = 0f;

    private float timePassed = 0f;

    public override bool isActive()
    {
        if (timePassed >= timeToWait)
        {
            timePassed = 0;
            return true;
        }
        timePassed += Time.deltaTime;
        return false;
    }
}
