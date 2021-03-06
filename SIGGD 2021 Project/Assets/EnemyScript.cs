using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    const int player = 3;
    const int enemy = 6;

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!health.IsDead())
            Debug.Log("The enemy detects the player.");
    }

    void OnTriggerLeft2D(Collider2D collider)
    {
        if (string.Equals(collider.name, "Player"))
        {
            if (!health.IsDead())
                Debug.Log("You exit the enemy's hearing range");
            if (collider.gameObject.layer == player)
            {
                Debug.Log("The enemy detects the player.");
            }
            else if (collider.gameObject.layer == enemy)
            {
                Debug.Log("Another enemy sounded an alarm.");
            }
        }
    }
}
