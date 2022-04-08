using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToLocation : Behavior
{
    private Transform player;
    [SerializeField] private Transform[] escapeLocations;
    [SerializeField] private NavmeshAgent navmeshAgent;
    public Vector2 escapeTarget = new Vector2(0,0);

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerNavPos>().transform;
    }

    public override void run()
    {
        navmeshAgent.navigateTo(escapeTarget);
    }

    public override void OnBehaviorEnter()
    {
        Transform bestEscape = transform;
        Transform secondBestEscape = escapeLocations[0];
        float bestDistance = Vector2.Distance(player.position, transform.position);
        foreach (Transform location in escapeLocations)
        {
            float newDistance = Vector3.Distance(player.position, location.position);
            if (newDistance > bestDistance)
            {
                secondBestEscape = bestEscape;
                bestDistance = newDistance;
                bestEscape = location;
            }
        }
        Debug.Log("Escaping to " + bestEscape.name);
        escapeTarget = secondBestEscape.position;
    }
    public override void OnBehaviorExit()
    {
        navmeshAgent.stopNavigation();
    }
}
