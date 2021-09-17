using UnityEngine;
using System.Collections.Generic;

// credit to Jason Weimann
[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    public void Invoke() { 
        foreach (var listener in listeners)
            listener.RaiseEvent();
    }

    public void Register(GameEventListener listener) => listeners.Add(listener);
    public void Deregister(GameEventListener listener) => listeners.Remove(listener);

}
