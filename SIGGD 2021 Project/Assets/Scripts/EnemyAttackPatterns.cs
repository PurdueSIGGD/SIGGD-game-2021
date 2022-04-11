using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPatterns : MonoBehaviour
{
    [SerializeField] private AttackData[] attacks;
    private float maxAttackRange = 1f;
    private float attackCooldown = 0f;
    [SerializeField] private string attackAnimName;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        //calculate the max attack range
        float max = 0;
        foreach (AttackData attack in attacks)
        {
            if (attack.range > max)
            {
                max = attack.range;
            }
        }
        maxAttackRange = max;
    }

    private void Update()
    {
        //always lowers the cooldown timer
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown < 0)
            {
                attackCooldown = 0;
            }
        }
    }

    public void chooseAttack(float sqrDistToPlayer, Transform attackTarget)
    {
        //select closest viable attack
        float min = float.PositiveInfinity;
        AttackData shortestAttack = null;
        foreach (AttackData attack in attacks)
        {
            if (attack.range < min && Mathf.Pow(attack.range, 2) >= sqrDistToPlayer)
            {
                min = attack.range;
                shortestAttack = attack;
            }
        }
        if (shortestAttack != null)
        {
            Debug.Log("attack created");

            animator.Play(attackAnimName);
            //create attack
            GameObject g = Instantiate(shortestAttack.projectileToSpawn, transform.position + (attackTarget.position - transform.position) * 0.5f, Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, attackTarget.position - transform.position, Vector3.forward)));
            attackCooldown += shortestAttack.cooldownAddition;
            g.GetComponent<Rigidbody2D>().velocity = g.transform.forward * shortestAttack.speed;
            g.GetComponent<enemyProjectile>().damage = shortestAttack.damage;
            Destroy(g, shortestAttack.duration);
        }

    }

    public float getMaxAttackRange()
    {
        return maxAttackRange;
    }

    public bool canAttack()
    {
        return attackCooldown > 0;
    }
}
