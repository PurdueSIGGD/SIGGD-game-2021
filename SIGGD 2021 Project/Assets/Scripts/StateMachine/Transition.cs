using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    public int toState;

    [SerializeField]
    public Trigger[] triggers;

    /*
     * gets called each frame to check if this transition should happen. If any triggers are true
     * then this transition will happen
     */
    public bool isTriggered()
    {
        if (triggers.Length == 0) { return true; } //if there are no triggers required for this transition then it happens
        foreach(Trigger trigger in triggers)
        {
            if (trigger.isActive())
            {
                return true;
            }
        }
        return false;
    }
}
