using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTrap : Behavior
{
    [SerializeField] private Transform trapOrigin;
    [SerializeField] private DestinationReached destinationReached;
    [SerializeField] private NavmeshAgent navmeshAgent;

    public override void run()
    {
        while (trapOrigin == null)
        {

        }
        navmeshAgent.navigateTo(trapOrigin.position);
    }

    public override void OnBehaviorEnter()
    {
        navmeshAgent = this.GetComponentInParent<NavmeshAgent>();
        while (trapOrigin == null)
        {

        }
        destinationReached.setDestination(trapOrigin.position);
    }

    public override void OnBehaviorExit()
    {

    }

    public void setDestination(Transform destination)
    {
        trapOrigin = destination;
    }
}
