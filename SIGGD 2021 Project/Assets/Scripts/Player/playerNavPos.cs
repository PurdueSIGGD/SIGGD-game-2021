using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNavPos : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask notInNavmesh;
    private bool isInTunnel = false;
    
    // Update is called once per frame
    void Update()
    {
        //if there is not a unreachable area around the player, set it to the player's location
        if (!isInTunnel && player != null && !Physics2D.CircleCast(player.position, 0.5f, transform.forward, 0f, notInNavmesh))
        {
            transform.position = player.position;
        }
    }

    public void setInTunnel(bool b)
    {
        isInTunnel = b;
    }
}
