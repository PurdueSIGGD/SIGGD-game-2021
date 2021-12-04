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
        Vector2 dir = soundOrigin - (Vector2)transform.position;
        Vector2 avoidLocation = (Vector2)transform.position + dir.normalized * 8;
        var result = Physics2D.Raycast(transform.position, dir, layerMask, 8);
        if (result)
        {
            avoidLocation = result.point - dir.normalized * 0.5f;
        }
        navmeshAgent.navigateTo(avoidLocation);
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
