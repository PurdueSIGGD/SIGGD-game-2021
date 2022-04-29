using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckPointScript : MonoBehaviour
{
    public GameObject player;
    public PlayerCheckpoint playerCheckpointScript;
    public TutorialManager manager;
    private Scene currScene;
    public GameObject enemies;

    private void Start()
    {
        enemies = GameObject.Find("Enemies");
        manager = GameObject.Find("Tutorial Manager").GetComponent<TutorialManager>();
        player = GameObject.Find("Player");
        currScene = SceneManager.GetActiveScene();
        playerCheckpointScript = player.GetComponent<PlayerCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCheckpointScript.checkpoint = new Vector2(gameObject.transform.position.x, 0);
            playerCheckpointScript.saveCheckpoint();
            manager.updateNavmash();

            if (currScene.name == "Sound_Tutorial")
            {
                if (gameObject == manager.checkpoints.transform.GetChild(0).gameObject)
                {
                    manager.tutorialTextObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "Press Shift to Run...";
                    enemies.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (gameObject == manager.checkpoints.transform.GetChild(1).gameObject)
                {
                    enemies.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            else 
            {
                if(gameObject == manager.checkpoints.transform.GetChild(0).gameObject)
                {
                    enemies.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
