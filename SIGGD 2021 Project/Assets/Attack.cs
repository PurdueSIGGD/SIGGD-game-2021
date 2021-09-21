using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackHitbox;
    public float range = .5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackHitbox.position, range, enemyLayers);

            foreach(Collider2D enemy in enemiesHit)
            {
                Debug.Log("We hit" + enemy.name);
            }

            
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackHitbox == null)
            return;

        Gizmos.DrawWireSphere(attackHitbox.position, range);
    }
}
