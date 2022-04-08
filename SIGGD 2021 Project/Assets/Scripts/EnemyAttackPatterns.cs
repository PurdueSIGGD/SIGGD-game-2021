using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPatterns : MonoBehaviour
{
    [SerializeField] private AttackData[] attacks;
    private float maxAttackRange = 1f;
    private float attackCooldown = 0f;

    private void Start()
    {
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

    public void chooseAttack()
    {
        
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
