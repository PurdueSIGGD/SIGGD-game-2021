using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public float radius = 5;
    public float damage = 5;

    void Explode()
    {
        Collider2D[] objectsFound = Physics2D.OverlapCircleAll(transform.position, radius);

    }
}
