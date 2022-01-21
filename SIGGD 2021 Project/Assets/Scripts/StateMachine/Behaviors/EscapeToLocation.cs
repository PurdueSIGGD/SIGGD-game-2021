using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToLocation : Behavior
{
    public Transform player;
    [SerializeField] private Transform[] escapeLocations;
    [SerializeField] private NavmeshAgent navmeshAgent;
    public Vector2 escapeTarget = new Vector2(0,0);

    public override void run()
    {
        //THIS CRASHES UNITY
        navmeshAgent.navigateTo(escapeTarget);
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
        Debug.Log("Escaping to " + bestEscape.name);
        escapeTarget = bestEscape.position;
    }
    public override void OnBehaviorExit()
    {
        navmeshAgent.stopNavigation();
    }
}
