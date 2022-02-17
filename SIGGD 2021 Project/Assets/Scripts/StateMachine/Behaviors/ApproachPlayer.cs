using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    public Transform player;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private SeeFaction seeFaction;

    public float approachSpeed = 1f;
    public override void run()
    {
        
        navmeshAgent.navigateTo(player.position);
    }

    public override void OnBehaviorEnter()
    {
        
    }
    public override void OnBehaviorExit()
    {
        seeFaction.setLookAngle(361);
        navmeshAgent.stopNavigation();
    }
}
