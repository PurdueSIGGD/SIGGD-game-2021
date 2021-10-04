using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public CircleCollider2D playerSound;

    public BoxCollider2D enemyHitbox;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
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
        if (!health.IsDead())
            Debug.Log("The enemy detects the player.");
    }

    void OnTriggerLeft2D(Collider2D playerSound)
    {
        if (!health.IsDead())
            Debug.Log("You exit the enemy's hearing range");
    }
}
