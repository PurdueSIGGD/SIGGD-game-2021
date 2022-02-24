using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGameEvent : MonoBehaviour
{
    public List<GameEvent> EventsToCall;

    // Script to call a GameEvent, typically through a UnityEvent
    public void Call()
    {
        foreach(GameEvent e in EventsToCall) {
            e.Invoke();
        }
    }
}
