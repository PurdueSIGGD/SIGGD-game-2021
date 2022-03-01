using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringGameEventListener : GameEventListenerGeneric<string>
{
    [SerializeField] StringGameEvent stringGameEvent;
    protected override GameEventGeneric<string> gameEvent => stringGameEvent;
}
