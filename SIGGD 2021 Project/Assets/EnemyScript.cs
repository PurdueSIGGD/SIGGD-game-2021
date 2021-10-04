using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public BoxCollider2D enemyHitbox;

    public int maxHP = 100;

    int currHP;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
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
        if (string.Equals(collider.name, "Player"))
        {
            Debug.Log("The enemy detects the player.");
        }
        else if (string.Equals(collider.name, "Enemy"))
        {
            Debug.Log("Another enemy sounded an alarm.");
        }
    }

    void OnTriggerLeft2D(Collider2D collider)
    {
        if (string.Equals(collider.name, "Player"))
        {
            Debug.Log("You exit the enemy's hearing range");
        }
        
    }
}
