using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    public Transform dest;
    private Vector2 oldPos;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private ConeRaycaster cone;

    public float approachSpeed = 1f;
    public override void run()
    {
        //this is to reduce the munber of path recalculations
        Vector2 playerV = dest.position;
        Vector2 enemyV = enemyTransform.position;
        float angle = Vector2.SignedAngle(Vector2.right, new Vector2(playerV.x - enemyV.x, playerV.y - enemyV.y));
        cone.setCenterAngle(angle);
        if (Mathf.Pow(playerV.x - oldPos.x, 2) + Mathf.Pow(playerV.y - oldPos.y, 2) > 1)
        {
            oldPos = playerV;
            navmeshAgent.navigateTo(playerV);
        } else
        {
            navmeshAgent.navigateTo(oldPos);
        }
    }

    public void setDest(Transform dest)
    {
        this.dest = dest;
    }

    public override void OnBehaviorEnter()
    {
        
    }
    public override void OnBehaviorExit()
    {
        navmeshAgent.stopNavigation();
    }
}
