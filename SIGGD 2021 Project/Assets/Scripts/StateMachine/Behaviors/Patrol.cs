using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Behavior
{
    public Route route = null; //the route that the enemy will follow
    public float enemyPatrolSpeed = 1f; //the speed that the enemy moves when patrolling

    private int currentNode = -1; //the current node that the enemy is at in the route
    private int patrolDirection = 1; //the direction that the enemy will patrol in (must be either -1 or 1)

    private bool invalidRoute = false; //if the route is invalid. if it is then the behavior shouldn't happen

    public override void run()
    {
        if (invalidRoute) { return; } //don't do anything if the route is invalid

        Vector3[] routeNodes = route.positionNodes(); //the nodes in the route

        //if there is no current node then make current node the closest route node to the enemy 
        if (currentNode == -1)
        {
            //find closest node on the route and make that your current node
            int closestNode = 0;
            float closestNodeDistance = Vector3.Distance(transform.position, routeNodes[closestNode]);
            for (int i = 1; i < routeNodes.Length; i++)
            {
                Vector3 node = routeNodes[i];
                float dist = Vector3.Distance(transform.position, node);
                if (dist < closestNodeDistance)
                {
                    closestNodeDistance = dist;
                    closestNode = i;
                }
            }
            currentNode = closestNode;
        }
        //if you are at the target node then go to the next node (or the last node depending on things)
        if (Vector2.Distance(transform.position, routeNodes[currentNode]) <= 0.5f) //arbitrary float value for determining when you are close enough to a node to be consitered at that node
        {
            if (patrolDirection == 1) //patrol through the nodes list in the forward direction
            {
                if (currentNode + 1 >= routeNodes.Length) //if you are at the end of the route
                {
                    if (route.isLoop) //if it's a loop then just loop back to the start 
                    {
                        currentNode = 0;
                    }
                    else //if it's not a loop then change directions and go the other way
                    {
                        currentNode--;
                        patrolDirection = -1;
                    }
                }
                else
                {
                    currentNode += patrolDirection;
                }
            }
            else //patrol through the nodes list in the backwards direction
            {
                if (currentNode - 1 < 0) //if you are at the begining of the route
                {
                    if (route.isLoop) //if it's a loop then just loop back to the start 
                    {
                        currentNode = routeNodes.Length - 1;
                    }
                    else //if it's not a loop then change directions and go the other way
                    {
                        currentNode++;
                        patrolDirection = 1;
                    }
                }
                else
                {
                    currentNode--;
                }
            }
        }
        //navigate towards the current node 
        Vector3 dirToNode = (routeNodes[currentNode] - transform.position).normalized;
        transform.Translate(dirToNode * Time.deltaTime * enemyPatrolSpeed);

    }

    public override void OnBehaviorEnter()
    {
        //error checking
        invalidRoute = false;
        if (route == null)
        {
            Debug.Log("Can't patrol because there is no route!");
            invalidRoute = true;
            return;
        }
        Vector3[] routeNodes = route.positionNodes();
        if (routeNodes.Length == 0)
        {
            Debug.Log("Can't patrol because there are no nodes in the route!");
            invalidRoute = true;
            return;
        }
        if (!route.isNavigatable())
        {
            Debug.Log("Can't patrol because route is not navigatable!");
            invalidRoute = true;
            return;
        }
        if (patrolDirection != -1 || patrolDirection != 1)
        {
            patrolDirection = 1;
        }
    }

    public override void OnBehaviorExit()
    {
        //reset variables
        currentNode = -1;
    }
}