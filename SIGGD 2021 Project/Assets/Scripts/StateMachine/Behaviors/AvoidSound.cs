using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSound : Behavior
{
    [SerializeField] private HearSound HearSound;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Route[] validPointViaRoutes;
    private bool pathing = false;
    private Vector2 soundOrigin;

    public override void run()
    {
        if (HearSound.position != null)
        {
            soundOrigin = HearSound.position.Value;
        }
        if (pathing)
        {
            return;
        }
        Transform[] nodes = validPointViaRoutes[Random.Range(0, validPointViaRoutes.Length)].transformNodes;
        navmeshAgent.navigateTo(nodes[Random.Range(0, nodes.Length)].position);
        pathing = true;
    }

    public override void OnBehaviorEnter()
    {
        destinationReached.setDestination(soundOrigin);
        pathing = false;
    }

    public override void OnBehaviorExit()
    {

    }
}
