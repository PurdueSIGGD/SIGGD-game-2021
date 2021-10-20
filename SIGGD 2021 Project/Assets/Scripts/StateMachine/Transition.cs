using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Transition
{
    public int toState;

    [SerializeField]
    public Trigger[] triggers;

    [SerializeField]
    public UnityEvent onTriggered;

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
                onTriggered.Invoke();
                return true;
            }
        }
        return false;
    }
}
