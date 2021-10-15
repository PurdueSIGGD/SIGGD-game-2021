using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : Trigger
{
    public Transform player;
    public bool NOT = false; //if true then SeePlayer returns if the enemy can NOT see the player
    [SerializeField] private Transform eyeTransform;
    public override bool isActive()
    {
        bool ret = NOT;
        LayerMask enemyMask = (int)Mathf.Pow(2, 7);
        LayerMask layerMask = ~enemyMask; //ignore collisions with the enemy
        RaycastHit2D hit = Physics2D.Linecast(eyeTransform.position, player.position); //draw a line between the enemy and the player
        if (hit.transform.gameObject.CompareTag("Player")) //if the line hits the player
        {
            Debug.DrawLine(eyeTransform.position, player.position, Color.green);
            return !ret;
        }
        Debug.DrawLine(eyeTransform.position, player.position, Color.red);
        return ret;
    }
}
