using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearSound : Trigger
{
    bool hearSound = false;
    private Transform soundTransform;

    override public bool isActive()
    {
        return hearSound;
    }

    private void OnTriggerEnter(Collider collider)
    {
        hearSound = true;
        soundTransform = collider.transform;
    }

    private void OnTriggerStay(Collider collider)
    {
        hearSound = true;
        soundTransform = collider.transform;
    }

    private void OnTriggerLeft(Collider collider)
    {
        //hearSound = false;
    }

    public Transform getSoundTransform()
    {
        return soundTransform;
    }
}
