using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachSound : Behavior
{
    [SerializeField] private Transform soundTransform;
    [SerializeField] private Transform currentLocation;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;

    private Vector2 soundOrigin;

    public override void run()
    {
        navmeshAgent.navigateTo(soundOrigin);
    }

    public override void OnBehaviorEnter()
    {
        soundOrigin = soundTransform.position;
        destinationReached.setDestination(soundOrigin);
    }

    public override void OnBehaviorExit()
    {

    }
}
