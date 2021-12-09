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
    [SerializeField] private Collider2D enemyCollider;
    [SerializeField] private LayerMask obscureLayer;
    private ContactFilter2D contactFilter = new ContactFilter2D();
    private List<Collider2D> colliderList = new List<Collider2D>(); 

    void Start()
    {
        contactFilter.SetLayerMask(obscureLayer);
    }
 
    
    public override bool isActive()
    {
        bool ret = NOT;

        // factionComp = gameObject.GetComponent<FactionComponent>();

        var hit = cone.Raycast((h) => h.transform.GetComponent<FactionComponent>()?.faction == targetFaction);

        enemyCollider.OverlapCollider(contactFilter, colliderList);

        bool lightsOff = false;

        if (colliderList.Count > 0)
        {
            Debug.Log("Vision Obscured");
            return false;
        }
        
        if (hit) //if the ray hits the faction
        {
            return !ret;
        }
        return ret;
    }
}
