using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachSound : Behavior
{
    [SerializeField] private Transform soundTransform;
    [SerializeField] private Transform currentLocation;
    [SerializeField] private NavmeshAgent navmeshAgent;

    private Transform soundOrigin;

    public override void run()
    {
        Vector2[] dirToSound = navmeshAgent.getPathTo(soundTransform.position);
        navmeshAgent.navigatePath(dirToSound);
    }

    public override void OnBehaviorEnter()
    {
        soundOrigin = soundTransform;
        
    }

    public override void OnBehaviorExit()
    {

    }

    public bool destinationReached()
    {
        if (soundOrigin.position == currentLocation.position)
        {
            return true;
        }

        return false;
    }
}
