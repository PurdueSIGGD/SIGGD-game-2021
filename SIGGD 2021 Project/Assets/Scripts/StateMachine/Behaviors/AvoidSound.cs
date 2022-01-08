using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSound : Behavior
{
    [SerializeField] private HearSound HearSound;
    [SerializeField] private Transform currentLocation;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;
    [SerializeField] private LayerMask layerMask;

    private Vector2 soundOrigin;

    public override void run()
    {
        Vector2 dir = (Vector2)transform.position - soundOrigin;
        Vector2 avoidLocation = (Vector2)transform.position + dir.normalized * 4;
        var result = Physics2D.Raycast(transform.position, dir, layerMask, 8);
        if (result)
        {
            avoidLocation = result.point - dir.normalized * 0.5f;
        }
        //navmeshAgent.navigateTo(avoidLocation);
        navmeshAgent.stopNavigation();
    }

    public override void OnBehaviorEnter()
    {
        soundOrigin = HearSound.position.Value;
        destinationReached.setDestination(soundOrigin);
    }

    public override void OnBehaviorExit()
    {

    }
}
