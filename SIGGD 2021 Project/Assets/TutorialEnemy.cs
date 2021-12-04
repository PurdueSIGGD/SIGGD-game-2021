using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    private GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("TutorialManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            manager.GetComponent<TutorialManager>().playerCaught = true;
        }
    }
}
