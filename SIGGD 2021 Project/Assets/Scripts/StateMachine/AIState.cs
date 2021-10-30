using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    public Behavior behavior; //the behaviour that will be run while this state is active

    [SerializeField]
    public AIStateTransition[] transitions; // transitions that could happen from this state
}

