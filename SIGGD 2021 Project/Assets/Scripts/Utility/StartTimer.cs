using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer : Trigger
{
    override public bool isActive()
    {
        return GetComponent<Timer>().IsFinished();
    }
}