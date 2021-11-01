using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Route : MonoBehaviour
{
    private bool navigatable = true;

    public Transform[] transformNodes; //the nodes in this route
    public bool isLoop = true; //if the route should loop around back to the starting position

    public Vector3[] positionNodes()
    {
        return transformNodes.Select(x => x.position).ToArray();
    }

    private void OnDrawGizmosSelected() //draw the route
    {
        LayerMask playerMask = (int)Mathf.Pow(2, 6); //layer 6
        LayerMask enemyMask = (int)Mathf.Pow(2, 7); //layer 7

        var nodes = this.positionNodes();

        for(int i = 0; i < nodes.Length; i++) 
        {
            Vector3 node = nodes[i];
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(node, 0.5f);
            Vector3 nextNode = nodes[0];
            if (i < nodes.Length - 1)
            {
                nextNode = nodes[i + 1];            
            }
            Color lineColor = Color.white;
            if (isLoop || nextNode != nodes[0])
            {
                LayerMask layerMask = ~(playerMask | enemyMask); //collide with all layers that are not the enemy or the player
                RaycastHit2D hit = Physics2D.Linecast(node, nextNode, layerMask);
                if (hit) //do raycasts to decide if next node is navigatable. it might be a bit improper to do this in gizmos so maybe move this later to start
                {
                    string hitTag = hit.transform.gameObject.tag;
                    if (hitTag != "Player" && hitTag != "Enemy")
                    {
                        lineColor = Color.red;
                        navigatable = false;
                    }
                    else
                    {
                        navigatable = true;
                    }
                }
                else
                {
                    navigatable = true;
                }
                Gizmos.color = lineColor;
                Gizmos.DrawLine(node, nextNode);
            }
            
        }

    }

    public bool isNavigatable()
    {
        return navigatable;
    }
}
