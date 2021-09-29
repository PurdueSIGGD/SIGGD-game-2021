using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    public Behavior behavior; //the behaviour that will be run while this state is active

    [SerializeField]
    public Transition[] transitions; // transitions that could happen from this state

}
