using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public GameObject player;
    public PlayerCheckpoint playerCheckpointScript;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerCheckpointScript = player.GetComponent<PlayerCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCheckpointScript.checkpoint = new Vector2(gameObject.transform.position.x, 0);
            playerCheckpointScript.saveCheckpoint();
        }
    }
}
