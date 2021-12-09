using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public GameObject manager;

    private void Start()
    {
        manager = GameObject.Find("Tutorial Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.GetComponent<TutorialManager>().checkPoint = new Vector2(gameObject.transform.position.x, 0);
        }
    }
}
