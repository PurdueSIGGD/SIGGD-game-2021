using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : Behavior
{
    private Transform player;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;

    private Vector2 playerLocation;

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerNavPos>().transform;
    }

    public override void run()
    {
        navmeshAgent.navigateTo(playerLocation);
    }

    public override void OnBehaviorEnter()
    {
        playerLocation = player.position;
        destinationReached.setDestination(playerLocation);
    }

    public override void OnBehaviorExit()
    {

    }
}
