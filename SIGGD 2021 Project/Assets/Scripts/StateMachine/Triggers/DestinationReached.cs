using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : Trigger
{
    
    [SerializeField] private Collider2D enemyCollider;
    [SerializeField] private NavmeshAgent enemyAgent;
    private Vector2 destination;

    public override bool isActive()
    {
        if (enemyCollider.bounds.Contains(destination) || enemyAgent.currentPath == null) //The second part is in case the destination cannot be reached
        {
            return true;
        }

        return false;
    }

    public void setDestination(Vector2 destination)
    {
        this.destination = destination;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
