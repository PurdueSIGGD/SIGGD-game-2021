using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VisionCheckpointScript : MonoBehaviour
{
    public GameObject player;
    public PlayerCheckpoint playerCheckpointScript;
    public VisionTutorialManager manager;
    private Scene currScene;
    public GameObject firstSectionEnemies;
    public GameObject secondSectionEnemies;
    public GameObject thirdSectionEnemies;

    private void Start()
    {
        manager = GameObject.Find("Tutorial Manager").GetComponent<VisionTutorialManager>();
        player = GameObject.Find("Player");
        playerCheckpointScript = player.GetComponent<PlayerCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerCheckpointScript.checkpoint = new Vector2(gameObject.transform.position.x, 0);
            playerCheckpointScript.saveCheckpoint();
            manager.updateNavmash();

            if (gameObject.transform.GetSiblingIndex() == 0)
            {
                firstSectionEnemies.SetActive(false);
                secondSectionEnemies.SetActive(true);
            }
            else
            {
                secondSectionEnemies.SetActive(false);
                thirdSectionEnemies.SetActive(true);
            }

        }
    }
}

