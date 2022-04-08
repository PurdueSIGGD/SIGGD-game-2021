using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    private Transform player;

    private Vector2 oldPos;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private EnemyAttackPatterns attackPatterns;
    [SerializeField] private ConeRaycaster cone;

    public float approachSpeed = 1f;

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerNavPos>().transform;
    }

    public override void run()
    {
        //this is to reduce the munber of path recalculations
        Vector2 playerV = player.position;
        Vector2 enemyV = transform.position;
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

        //checks if close enough to attack, and if so, does
        if (attackPatterns.canAttack() && Mathf.Pow(playerV.x - oldPos.x, 2) + Mathf.Pow(playerV.y - oldPos.y, 2) > Mathf.Pow(attackPatterns.getMaxAttackRange(), 2))
        {
            attackPatterns.chooseAttack();
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
