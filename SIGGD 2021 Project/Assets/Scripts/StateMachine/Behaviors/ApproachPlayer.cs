using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    public Transform player;
    private Vector2 oldPos;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private NavmeshAgent navmeshAgent;

    public float approachSpeed = 1f;
    public override void run()
    {
        //this is to reduce the munber of path recalculations
        Vector2 newPos = player.position;
        if (Mathf.Pow(newPos.x - oldPos.x, 2) + Mathf.Pow(newPos.y - oldPos.y, 2) > 1)
        {
            oldPos = newPos;
            navmeshAgent.navigateTo(newPos);
        } else
        {
            navmeshAgent.navigateTo(oldPos);
        }
    }

    public override void OnBehaviorEnter()
    {
        
    }
    public override void OnBehaviorExit()
    {
        navmeshAgent.stopNavigation();
    }
}
