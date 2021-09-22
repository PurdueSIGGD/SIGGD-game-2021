using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    private bool navigatable = true;

    public Vector3[] nodes;
    public bool isLoop = true;

    private void OnDrawGizmosSelected()
    {
        LayerMask playerMask = (int)Mathf.Pow(2, 6); //layer 6
        LayerMask enemyMask = (int)Mathf.Pow(2, 7); //layer 7

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
                if (hit)
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
