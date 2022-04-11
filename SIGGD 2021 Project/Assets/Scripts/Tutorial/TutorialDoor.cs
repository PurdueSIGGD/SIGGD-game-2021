using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialDoor : MonoBehaviour
{
    public bool isPlayerInCollider = false;
    public float distance;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    public void movePlayer()
    {
        if(isPlayerInCollider)
        {
            player.transform.position = new Vector2(player.transform.position.x + distance, player.transform.position.y);
            Debug.Log("Works");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isPlayerInCollider = false;
        }
    }
}
