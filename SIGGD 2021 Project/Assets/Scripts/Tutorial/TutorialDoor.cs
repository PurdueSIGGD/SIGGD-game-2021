using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TutorialDoor : MonoBehaviour
{
    public bool isPlayerInCollider = false;
    public float distance;
    public GameObject player;
    public Scene currScene;
    public string nextScene;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currScene = SceneManager.GetActiveScene();

        if(currScene.name == "Sound_Tutorial")
        {
            nextScene = ("Vision_Tutorial");
        }
        else
        {
            nextScene = ("startMenu");
        }
    }

    public void movePlayer()
    {
        if (isPlayerInCollider && gameObject.name == "SceneDoor")
        {
            GlobalControl.Instance.checkpoint = new Vector2(0, 0);
            SceneManager.LoadScene(nextScene);
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
