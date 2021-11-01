using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : Trigger
{
    [SerializeField] private ApproachSound approachSound;

    public override bool isActive()
    {
        return approachSound.destinationReached();
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
