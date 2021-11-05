using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Trigger : MonoBehaviour
{
    /*
     * Gets called each frame by the transition that this trigger is associated with to determine if the trigger should be triggered. 
     */
    public abstract bool isActive();
}
