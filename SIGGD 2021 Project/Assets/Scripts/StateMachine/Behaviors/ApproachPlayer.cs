using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachPlayer : Behavior
{
    public Transform player;

    public float approachSpeed = 1f;
    public override void run()
    {
        Vector3 dirToPlayer = (player.position - transform.position).normalized;
        transform.Translate(dirToPlayer * Time.deltaTime * approachSpeed);
    }

    public override void OnBehaviorEnter()
    { 

    }
    public override void OnBehaviorExit()
    {
        
    }
}