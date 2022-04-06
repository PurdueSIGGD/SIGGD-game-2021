using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("Tutorial Manager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {
            manager.GetComponent<TutorialManager>().playerCaught();
        }
    }
}
