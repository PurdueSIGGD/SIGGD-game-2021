using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeFaction : Trigger
{
    // public Transform player;
    public bool NOT = false; //if true then SeePlayer returns if the enemy can NOT see the player
    public ConeRaycaster cone; // Cone script 
    [SerializeField] private Transform eyeTransform;
    [SerializeField] private LayerMask layerMask;
    // [SerializeField] private FactionComponent factionComp;
    [SerializeField] private EntityFaction targetFaction;
    [SerializeField] private float lookAngle = 361;
    
    public override bool isActive()
    {
        bool ret = NOT;

        // factionComp = gameObject.GetComponent<FactionComponent>();

        var hit = cone.Raycast((h) => h.transform.GetComponent<FactionComponent>()?.faction == targetFaction, lookAngle);

        if (hit) //if the ray hits the faction
        {
            return !ret;
        }
        return ret;
    }

    public setLookAngle(float angle)
    {
        lookAngle = angle;
    }
}
