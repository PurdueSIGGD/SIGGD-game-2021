using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckPointScript : MonoBehaviour
{
    public GameObject player;
    public PlayerCheckpoint playerCheckpointScript;
    public TutorialManager manager;

    private void Start()
    {
        manager = GameObject.Find("Tutorial Manager").GetComponent<TutorialManager>();
        player = GameObject.Find("Player");
        playerCheckpointScript = player.GetComponent<PlayerCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCheckpointScript.checkpoint = new Vector2(gameObject.transform.position.x, 0);
            playerCheckpointScript.saveCheckpoint();
            manager.updateNavmash();

            if(gameObject == manager.checkpoints.transform.GetChild(0).gameObject)
            {
                manager.tutorialTextObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Press Shift to Run...";
            }
        }
    }
}
