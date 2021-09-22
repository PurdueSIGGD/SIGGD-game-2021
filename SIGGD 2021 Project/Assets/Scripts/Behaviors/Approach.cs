using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : EnemyBehavior
{
    private Transform playerPos;
    public float enemySpeed = 1f;

    private void Start()
    {
        playerPos = gameObject.GetComponent<EnemyMovement>().playerPos;
    }
    public override void doBehavior()
    {
        Vector3 dirToPlayer = (playerPos.position - transform.position).normalized;
        transform.Translate(dirToPlayer * Time.deltaTime * enemySpeed);
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }
}
