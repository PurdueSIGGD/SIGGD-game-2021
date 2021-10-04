using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackHitbox;
    public Transform playerLocation;
    public LayerMask enemyLayers;

    public float range = .8f;
    float delay = .5f;
    float timeElapsed = 0f;
    int attackDamage = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeElapsed > delay)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackHitbox.position, range, enemyLayers);

                foreach (Collider2D enemy in enemiesHit)
                {
                    Debug.Log("We hit " + enemy.name);
                    enemy.GetComponent<Health>().TakeDamage(attackDamage);
                }

                timeElapsed = 0;
            }
        }
        else if (timeElapsed < delay)
        {
            timeElapsed += Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackHitbox == null)
            return;

        Gizmos.DrawWireSphere(attackHitbox.position, range);
    }
}
