using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : Trigger
{
    public Transform player;
    public bool NOT = false; //if true then SeePlayer returns if the enemy can NOT see the player
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private LayerMask layerMask;
    public override bool isActive()
    {
        bool ret = NOT;
        RaycastHit2D hit = Physics2D.Linecast(eyeTransform.position, player.position, layerMask); //draw a line between the enemy and the player
        if (hit.transform.gameObject.CompareTag("Player")) //if the line hits the player
        {
            Debug.DrawLine(eyeTransform.position, player.position, Color.green);
            return !ret;
        }
        Debug.DrawLine(eyeTransform.position, player.position, Color.red);
        return ret;
    }
}
