using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavmeshAgent : MonoBehaviour
{
    public float agentSpeed = 1f;

    private Navmesh navmesh;

    public Vector2[] currentPath = null;
    private int currentNode = 0;
    private Vector2 currentTarget = Vector2.zero;
    private bool atTarget = true;
    public Transform bodyHolder;
    public int compassDirection;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = FindObjectOfType<Navmesh>();
    }

    private void Update()
    {
        if (!atTarget)
        {
            Vector2 dirToCurrentNode = (currentPath[currentNode] - new Vector2(transform.position.x, transform.position.y)).normalized; //direction to next node
            transform.Translate(dirToCurrentNode * Time.deltaTime * agentSpeed, Space.World); //go in direction to next node
        }
        bodyHolder.rotation = Quaternion.Euler(0, 0, 90 * (compassDirection + 1));
    }

    /**
     * Given a target position, will return a path (Vector2 array) to that position
     */
    public Vector2[] getPathTo(Vector2 target)
    {
        Vector2 start = transform.position;
        return navmesh.getPath(start, target);
    }

    /**
     * Navigates a path (Vector2 array) 
     */
    public void navigatePath(Vector2[] path)
    {
        if (path.Length <= 0) //check for empty path
        {
            Debug.Log("Cannot navigate empty path!");
            atTarget = true;
            currentPath = null;
            currentNode = 0;
            return;
        }
        if (Mathf.Pow(transform.position.x - currentPath[currentNode].x, 2) + Mathf.Pow(transform.position.y - currentPath[currentNode].y, 2) < 0.1f) //arbitrary value for determining if the agent is close enough to the position to be consitered at the position
        {
            if (currentNode == currentPath.Length - 1) //if you are at the end of the path then stop
            {
                stopNavigation();
                return;
            }
            currentNode++; //if at node then go to next node
        }

        Vector2 dirToCurrentNode = (currentPath[currentNode] - new Vector2(transform.position.x, transform.position.y)).normalized; //direction to next node
        transform.Translate(dirToCurrentNode * Time.deltaTime * agentSpeed); //go in direction to next node

        //Calculate compass direction
        float angle = Vector2.SignedAngle(Vector2.right, dirToCurrentNode);
        if (currentNode > 0)
        {
            angle = Vector2.SignedAngle(Vector2.right, currentPath[currentNode] - currentPath[currentNode - 1]);
        }
        angle = Mathf.Round(angle/90);
        if (angle < 0)
        {
            angle += 4;
        }
        compassDirection = (int)angle;

        //draw the path
        if (true) //Turn on if debugging
        {
            for (int i = 1; i < path.Length; i++)
            {
                Debug.DrawLine(path[i - 1], path[i], Color.blue);
            }
        }
    }

    /**
     * Will move the player towards a target position using the navmesh. Must be called every frame 
     */
    public void navigateTo(Vector2 target)
    {
        if (target != currentTarget) //if the target is not the location that you are currently navigating to
        {
            currentTarget = target;
            currentPath = getPathTo(target);
            currentNode = 0;
            int nextNode = currentNode + 1;

            //if the distance from the player to the next node is less than the distance from the current node to the next node then go to the next node instead 
            float distFromPlayerToNextNode = Vector2.Distance(transform.position, currentPath[nextNode]);
            float distFromCurrentNodeToNextNode = Vector2.Distance(currentPath[currentNode], currentPath[nextNode]);
            if (distFromPlayerToNextNode < distFromCurrentNodeToNextNode)
            {
                currentNode++;
            }

            atTarget = false;
        } 
        if (atTarget) { return; } //if target == current target and you are at that target then don't do anything
        navigatePath(currentPath);
    }

    /**
     * stops navigation and resets navigation variables
     */
    public void stopNavigation()
    {
        atTarget = true;
        currentPath = null;
        currentNode = 0;
    }

    public void setAgentSpeed(float agentSpeed)
    {
        this.agentSpeed = agentSpeed;
    }
}
