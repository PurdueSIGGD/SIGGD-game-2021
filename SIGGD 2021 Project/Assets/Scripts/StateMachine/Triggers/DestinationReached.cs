using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : Trigger
{
    
    [SerializeField] private Collider2D enemyCollider;
    private Vector2 destination;

    public override bool isActive()
    {
        if (enemyCollider.bounds.Contains(destination))
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
