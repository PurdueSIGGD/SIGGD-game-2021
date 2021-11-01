using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{

    [SerializeField]
    private AIState activeState; //the state that is currently active


    private void Start()
    {
        if (activeState == null) {
            Debug.LogError("Active state must have initial value!");
        }
    }

    private void Update()
    {
        foreach (AIStateTransition transition in activeState.transitions) //loop through all transitions going from this state and ask them if the right conditions have been met for them to be triggered
        {
            if(transition.isTriggered()) //if a transition is triggered then switch to that transition's state
            {
                switchState(transition.toState); 
            }
        }
        activeState.behavior.run(); //run the state behavior of the current active state
    }

    private void switchState(AIState newState)
    {
        activeState.behavior.OnBehaviorExit();
        activeState = newState;
        newState.behavior.OnBehaviorEnter();
    }
}

