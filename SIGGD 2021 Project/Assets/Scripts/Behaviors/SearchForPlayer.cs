using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : EnemyBehavior
{
    private Vector3 lastKnownPosition = Vector3.zero; //last known player position. Vector3.zero is used as a null value
    private Vector3 lastKnownDirection = Vector3.zero; //last known player direction. Vector3.zero is used as a null value
    private bool atLastKnownLocation = false;

    private float timeToSearchFor = 10f; //the time in seconds to search for the player once the enemy arrives at the last known location
    private float timeSpentSearching = 0f; //the time in seconds that has been spent searching for the player

    private Transform playerPos;

    public float enemySearchSpeed = 2f; //the speed that the enemy moves when searching

    private void Start()
    {
        playerPos = gameObject.GetComponent<EnemyMovement>().playerPos;
    }

    public bool doneSearching()
    {
        return timeSpentSearching >= timeToSearchFor;
    }

    public override void doBehavior()
    {
        //instantiate player direction if it hasn't been already
        if(lastKnownDirection == Vector3.zero && playerPos.position != lastKnownPosition)
        {
            lastKnownDirection = (playerPos.position - lastKnownPosition).normalized;
        }

        if (!atLastKnownLocation) //if not at last known location then go towards last known location
        {
            Vector3 dirToLastPos = (lastKnownPosition - transform.position).normalized;
            transform.Translate(dirToLastPos * Time.deltaTime * enemySearchSpeed);
            if (Vector3.Distance(transform.position, lastKnownPosition) <= 0.5f) //if at last known location then change bool
            {
                atLastKnownLocation = true;
            }
        }
        else //if at last known location then search for player 
        {
            //TODO: implement search behavior
            //for now just increment time spent searching and wait for the search timer to run out
            timeSpentSearching += Time.deltaTime;
            if (timeSpentSearching >= timeToSearchFor)
            {
                EnemyMovement enemyMovement = gameObject.GetComponent<EnemyMovement>();
                enemyMovement.setState(enemyMovement.defaultState); //if couldn't find player go back to default state
            }
        }

        //debug draw last known location and direction
        Vector3 cross = Vector3.Cross(lastKnownDirection, Vector3.forward).normalized;
        Debug.DrawRay(lastKnownPosition, cross * 0.1f, Color.blue);
        Debug.DrawRay(lastKnownPosition, cross * -0.1f, Color.blue);
        Debug.DrawRay(lastKnownPosition, lastKnownDirection, Color.grey);

    }

    public override void OnStateEnter()
    {
        lastKnownPosition = playerPos.position;
    }

    public override void OnStateExit()
    {
        timeSpentSearching = 0f;
        lastKnownPosition = Vector3.zero;
        lastKnownDirection = Vector3.zero;
        atLastKnownLocation = false;
    }
}
