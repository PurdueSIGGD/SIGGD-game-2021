using UnityEngine;
public class FloatGameEventListener : GameEventListenerGeneric<float>
{
    [SerializeField] FloatGameEvent floatGameEvent;
    protected override GameEventGeneric<float> gameEvent => floatGameEvent;
}