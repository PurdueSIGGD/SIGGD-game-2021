using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeFaction : Trigger
{
    public Transform player;
    public bool NOT = false; //if true then SeePlayer returns if the enemy can NOT see the player
    public bool isFactionSame; // True if the faction between the enemy and the player same
    public ConeRaycaster cone; // Cone script 
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private FactionComponent factionComp;
    
    public override bool isActive()
    {
        bool ret = NOT;

        factionComp = gameObject.GetComponent<FactionComponent>();

        //draw a line between the enemy and the player
        RaycastHit2D hit = Physics2D.Linecast(eyeTransform.position, player.position, layerMask); 

        if (cone.raycast() && hit.transform.gameObject.CompareTag("Player")) //if the line hits the player
        {
            if (factionComp.faction == hit.transform.gameObject.GetComponent<FactionComponent>().faction) // Check if the hit faction and the enemy faction are the same
            {
                // Event to trigger if same factions  
                isFactionSame = true;
            }
            else
            {
                // Event to trigger if different factions (e.g. agro)
                isFactionSame = false;
            }

            Debug.DrawLine(eyeTransform.position, player.position, Color.green);
            return !ret;
        } else {
            Debug.DrawLine(eyeTransform.position, player.position, Color.red);
        }
        return ret;
    }
}
