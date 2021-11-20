using UnityEngine;
public class IntGameEventListener : GameEventListenerGeneric<int>
{
    [SerializeField] IntGameEvent intGameEvent;
    protected override GameEventGeneric<int> gameEvent => intGameEvent;
}