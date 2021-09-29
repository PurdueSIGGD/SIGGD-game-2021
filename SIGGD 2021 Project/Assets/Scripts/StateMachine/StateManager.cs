using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    public State[] states; //the different states that make up this state manager.

    private State activeState; //the state that is currently active

    private void Start()
    {
        if (states.Length == 0) { return; } //probably shouldn't need this but just in case
        activeState = states[0]; //the active state starts out as the state that is in the 0 position in the array
    }

    private void Update()
    {
        if (states.Length == 0) { return; } //or this
        foreach (Transition transition in activeState.transitions) //loop through all transitions going from this state and ask them if the right conditions have been met for them to be triggered
        {
            if(transition.isTriggered()) //if a transition is triggered then switch to that transition's state
            {
                switchState(states[transition.toState]); 
            }
        }
        activeState.behavior.run(); //run the state behavior of the current active state
    }

    private void switchState(State newState)
    {
        activeState.behavior.OnBehaviorExit();
        activeState = newState;
        newState.behavior.OnBehaviorEnter();
    }
}
