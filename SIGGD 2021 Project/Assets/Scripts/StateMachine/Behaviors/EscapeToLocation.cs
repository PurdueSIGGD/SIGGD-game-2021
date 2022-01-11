using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToLocation : Behavior
{
    public Transform player;
    [SerializeField] private Transform[] escapeLocations;
    [SerializeField] private NavmeshAgent navmeshAgent;

    public override void run()
    {
        Transform bestEscape = transform;
        float bestDistance = Vector2.Distance(player.position, transform.position);
        foreach (Transform location in escapeLocations)
        {
            float newDistance = Vector3.Distance(player.position, location.position);
            if (newDistance > bestDistance)
            {
                bestDistance = newDistance;
                bestEscape = location;
            }
        }
        navmeshAgent.navigateTo(bestEscape.position);
    }

    public override void OnBehaviorEnter()
    {

    }
    public override void OnBehaviorExit()
    {

    }
}
