using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSound : Behavior
{
    [SerializeField] private HearSound HearSound;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float stepSize = 1f;

    private Vector2 soundOrigin;

    public override void run()
    {
        if (HearSound.position != null)
        {
            soundOrigin = HearSound.position.Value;
        }
        Vector2 dir = (Vector2)transform.position - soundOrigin;
        Vector2 avoidLocation = (Vector2)transform.position + dir.normalized * stepSize;
        var result = Physics2D.Raycast(transform.position, dir, stepSize, layerMask);
        if (!result)
        {
            navmeshAgent.navigateTo(avoidLocation);
        } else
        {
            navmeshAgent.stopNavigation();
        }
    }

    public override void OnBehaviorEnter()
    {
        destinationReached.setDestination(soundOrigin);
    }

    public override void OnBehaviorExit()
    {

    }
}
