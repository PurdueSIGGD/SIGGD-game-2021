using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearSound : Trigger
{
    public bool NOT;
    bool hearSound = false;

    override public bool isActive()
    {
        return (hearSound && !NOT);
    }

    private void OnTriggerEnter(Collider collider)
    {
        hearSound = true;
    }

    private void OnTriggerLeft(Collider collider)
    {
        hearSound = false;
    }
}
