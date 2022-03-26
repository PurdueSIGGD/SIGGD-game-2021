using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : Behavior
{
    [SerializeField] private ApproachPlayer approachPlayer;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;

    private Vector2 playerLocation;

    public override void run()
    {
        navmeshAgent.navigateTo(approachPlayer.dest.position);
    }

    public override void OnBehaviorEnter()
    {
        destinationReached.setDestination(approachPlayer.dest.position);
    }

    public override void OnBehaviorExit()
    {

    }
}
