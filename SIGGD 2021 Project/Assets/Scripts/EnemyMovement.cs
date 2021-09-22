using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script that controls what movement state the player will in and calls the correct movement functions in the corresponding implementations of the abstract EnemyBehavior class
 */
public class EnemyMovement : MonoBehaviour
{
    public EnemyBehavior[] behaviors;

    /**
    * The index of the current behavior script that should be run. If you want your script to be
    * run not only should you add it to the array but you should add an enum and change some
    * logic in the decideState function so that your state gets set when something happens
    */
    public enum State
    {
        Idle,
        Wander,
        Patrol,
        Approach,
        Search
    }
    
    public Transform playerPos; //the position of the player

    public State defaultState = State.Idle; //the state that the enemy will default to

    private State currentState; //the current state of the enemy

    private LayerMask enemyMask = (int)Mathf.Pow(2, 7); //layer 7

    // Start is called before the first frame update
    void Start()
    {
        currentState = defaultState;
    }

    // Update is called once per frame
    void Update()
    {
        //decide what state to be in. see implementation for specifics
        decideState();

        //call behavior function based on state
        behaviors[(int)currentState].doBehavior();   
    }

    /**
     * Decides what state the enemy should be in. The default logic is that the
     * enemy will be in the default state unless they see the player in which 
     * case they will move to the approaching state. If the player moves out of
     * view they will move to the searching state and then, after some time, 
     * they will return to the default state. This method can be overridden in 
     * subclasses to allow for different logic for deciding enemy states. 
     */
    private void decideState()
    {
        if (playerIsVisible()) //if you see the player then approach them
        {
            setState(State.Approach);
            if (Vector3.Distance(playerPos.position, transform.position) < 0.5f) //if you are at the player then do something
            {
                //don't know what that's going to be yet though so for now just go to idle
                //TODO: maybe add some attack behavior that gets switched to here
                setState(State.Idle); 
            }
        } else if (currentState == State.Approach) //if are approaching the player but you dont see them
        {
            setState(State.Search);
        }
        else if (currentState == State.Search) //if you are searching then don't do anything and wait 
        {
            //do nothing and wait for the search function to change the state once it's done searching. this logic could also be done in this script
            //but I decided to put in in the search script. idk which one is better
        }
        else
        {
            setState(defaultState); //default to default state
        }
    }

    /**
     * Calls the OnStateExit function of the current state's behavior and sets the current state to the new state and calls the OnStateEnter function on the new state's behavior
     */
    public void setState(State newState)
    {
        if (newState == currentState) { return; }
        
        behaviors[(int)currentState].OnStateExit();
        currentState = newState;
        behaviors[(int)currentState].OnStateEnter();
    }

    /*
     * returns true if a a line can be drawn from the enemy to the player without hitting anything
     * TODO: implement view cone visibility instead of this system
     */
    private bool playerIsVisible()
    {
        LayerMask layerMask = ~enemyMask; //collide with all layers that are not the enemy
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerPos.position, layerMask); //cast a line between the enemy position and the player position
        if (hit.transform.gameObject.CompareTag("Player")) //if the line hits the player then the player is visible
        {
            Debug.DrawLine(transform.position, playerPos.position, Color.green);
            return true;
        }
        Debug.DrawLine(transform.position, playerPos.position, Color.red);
        return false;
    }
}
