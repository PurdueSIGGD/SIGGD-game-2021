using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour
{
    public CircleCollider2D playerSound;

    public BoxCollider2D enemyHitbox;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D playerSound)
    {
        Debug.Log("The enemy detects the player.");
    }

    void OnTriggerLeft2D(Collider2D playerSound)
    {
        Debug.Log("You exit the enemy's hearing range");
    }
}
