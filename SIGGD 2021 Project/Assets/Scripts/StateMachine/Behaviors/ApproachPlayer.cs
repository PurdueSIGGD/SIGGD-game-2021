using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    public Transform player;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private ConeRaycaster cone;

    public float approachSpeed = 1f;
    public override void run()
    {
        Vector2 playerV = player.position;
        Vector2 enemyV = enemyTransform.position;
        float angle = Vector2.SignedAngle(Vector2.right, new Vector2(playerV.x - enemyV.x, playerV.y - enemyV.y));
        Debug.Log("behavior " + angle);
        cone.setCenterAngle(angle);
        navmeshAgent.navigateTo(player.position);
    }

    public override void OnBehaviorEnter()
    {

    }
    public override void OnBehaviorExit()
    {
        cone.setCenterAngle(361);
        navmeshAgent.stopNavigation();
    }
}
