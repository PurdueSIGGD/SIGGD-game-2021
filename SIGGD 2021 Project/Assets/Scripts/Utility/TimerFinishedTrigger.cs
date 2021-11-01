using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFinishedTrigger : Trigger
{
    [SerializeField] private Timer timer;
    public override bool isActive()
    {
        return timer.IsFinished();
    }
}