using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachTrap : Behavior
{
    [SerializeField] private Transform trapOrigin;
    [SerializeField] private DestinationReached destinationReached;
    [SerializeField] private NavmeshAgent navmeshAgent;

    [SerializeField] private Trap[] traps;
    // List of all corresponding traps to this enemy

    public override void run()
    {
        navmeshAgent.navigateTo(trapOrigin.position);
    }

    public override void OnBehaviorEnter()
    {
        navmeshAgent = this.GetComponentInParent<NavmeshAgent>();
        destinationReached.setDestination(trapOrigin.position);
    } // get navmesh from parent, set destinationReached's destination to the trap's position.

    public override void OnBehaviorExit()
    {
        foreach(Trap trap in traps) {
            trap.reActivate();
        } // reactivates all traps
    }

    public void setDestination(Transform destination)
    {
        trapOrigin = destination;
    } // this allows Trap to pass its transform to the behavior. See TrapTriggered and Trap for more details
}
