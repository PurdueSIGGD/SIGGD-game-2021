using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    /**
     * This gets called every frame in EnemyMovement. Put code for enemy behavior here.
     */
    public abstract void doBehavior();

    /**
     * Gets called in EnemyMovement when a new state is entered from a previous state
     */
    public abstract void OnStateEnter();

    /**
     * Gets called in EnemyMovement when a state is exited to a new state
     */
    public abstract void OnStateExit();
}
