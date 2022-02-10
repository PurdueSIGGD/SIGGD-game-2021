using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearSound : Trigger, ISoundSignalListener
{
    public Vector3? position {get; private set;}
    [SerializeField] private int soundType = 0;
    [SerializeField] private float disregardTime = 5;
    private float disregardCounter = 0;
    // private Transform soundTransform;

    private void Update()
    {
        disregardCounter += Time.deltaTime;
        if (disregardCounter >= disregardTime)
        {
            DisregardSound();
        }
    }

    override public bool isActive()
    {
        return position.HasValue;
    }

    public void Signal(Vector3 point, int origin) //0 = from player (movement/actions), 1 = from enemy (call for help/alerts), 2 = other
    {
        if (origin == soundType)
        {
            position = point;
            disregardCounter = 0;
        }
    }

    public void DisregardSound() {
        position = null;
    }

}
