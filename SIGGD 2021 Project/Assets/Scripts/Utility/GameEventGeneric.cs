using UnityEngine;
using System.Collections.Generic;

public class GameEventGeneric<T> : ScriptableObject {
    private HashSet<GameEventListenerGeneric<T>> listeners = 
        new HashSet<GameEventListenerGeneric<T>>();

    public void Invoke(T input) { 
        foreach (var listener in listeners)
            listener.RaiseEvent(input);
    }

    public void Register(GameEventListenerGeneric<T> listener) => listeners.Add(listener);
    public void Deregister(GameEventListenerGeneric<T> listener) => listeners.Remove(listener);
}