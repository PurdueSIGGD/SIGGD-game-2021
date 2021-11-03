using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearSound : Trigger, ISoundSignalListener
{
    public Vector3? position {get; private set;}
    // private Transform soundTransform;

    override public bool isActive()
    {
        return position.HasValue;
    }

    public void Signal(Vector3 point)
    {
        position = point;
    }

    public void DisregardSound() {
        position = null;
    }

}
