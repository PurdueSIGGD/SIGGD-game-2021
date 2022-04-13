using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private UnityEvent missEvent;

    [SerializeField] private float offset = 1f;
    [SerializeField] private float range = .5f;
    const float delay = 1f;
    static float timeElapsed = 0f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private Movement playerMovement;
    private Vector3 lastMovement = Vector3.right;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeElapsed >= delay)
        {
            if (isAttacking())
            {
                if (playerMovement.isMoving())
                {
                    lastMovement = playerMovement.movement.normalized;
                    Debug.Log("Updated movement");
                }

                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position + lastMovement * offset, range, enemyLayers);

                if (enemiesHit.Length == 0) missEvent.Invoke();

                foreach (Collider2D enemy in enemiesHit)
                {
                    Debug.Log(string.Format("Hit {0}", enemy.name));
                    enemy.gameObject.GetComponent<Health>().TakeDamage(attackDamage);
                }

                timeElapsed = 0f;
            }
        }
        else if (timeElapsed < delay)
        {
            timeElapsed += Time.fixedDeltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere(transform.position + lastMovement * offset, range);
        //Since this only updates on attack, seeing it in the inspector can be misleading
    }

    public bool isAttacking() {
        return Input.GetKey(KeyCode.Space);
    }
}