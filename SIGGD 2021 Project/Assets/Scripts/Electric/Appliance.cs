using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliance : Power
{
    private bool isPowered = false;
    private bool isDisabled = false;

    public override void propagate(bool value)
    {
        if (!isDisabled)
        {
            isPowered = value;
        }
        else
        {
            isPowered = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPowered)
        {
            //do something
        }
    }
}
