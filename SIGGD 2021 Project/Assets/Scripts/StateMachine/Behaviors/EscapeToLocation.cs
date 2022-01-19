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
        
    }

    public override void OnBehaviorEnter()
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
        //THIS CRASHES UNITY
        //navmeshAgent.navigateTo(bestEscape.position);
        Debug.Log("Escaping to " + bestEscape.name);
    }
    public override void OnBehaviorExit()
    {

    }
}
