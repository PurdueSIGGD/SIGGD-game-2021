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
    bool isExecuted = false;

    private void Start()
    {
        manager = GameObject.Find("Tutorial Manager").GetComponent<VisionTutorialManager>();
        player = GameObject.Find("Player");
        playerCheckpointScript = player.GetComponent<PlayerCheckpoint>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !isExecuted)
        {
            isExecuted = !isExecuted;
            playerCheckpointScript.checkpoint = new Vector2(gameObject.transform.position.x, 0);
            playerCheckpointScript.saveCheckpoint();
            firstSectionEnemies.SetActive(false);
            manager.updateNavmash();
            secondSectionEnemies.SetActive(true);

        }
    }
}

