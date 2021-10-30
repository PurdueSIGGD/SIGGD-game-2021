using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeFaction : Trigger
{
    public Transform player;
    public bool NOT = false; //if true then SeePlayer returns if the enemy can NOT see the player
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private FactionComponent factionComp;
    public override bool isActive()
    {
        bool ret = NOT;

        //draw a line between the enemy and the player
        RaycastHit2D hit = Physics2D.Linecast(eyeTransform.position, player.position, layerMask); 
        if (hit && hit.transform.gameObject.CompareTag("Player")) //if the line hits the player
        {
            Debug.DrawLine(eyeTransform.position, player.position, Color.green);
            return !ret;
        } else {
            Debug.DrawLine(eyeTransform.position, player.position, Color.red);
        }
        return ret;
    }
}
