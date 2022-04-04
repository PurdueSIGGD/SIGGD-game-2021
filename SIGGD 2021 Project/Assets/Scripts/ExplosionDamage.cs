using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public LayerMask mask;
    public float radius = 5;
    public float damage = 5;

    public void Explode()
    {
        Collider2D[] objectsFound = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D obj in objectsFound)
        {
            ProcessDamage(obj.gameObject);
        }
    }

    void ProcessDamage(GameObject gm)
    {
        Debug.Log("checking " + gm.name);

        // Don't damage things with no health
        Health hp = gm.GetComponent<Health>();
        if (!hp) return;

        Debug.Log("Has HP");

        // Otherwise, check if there is a line of effect, then scale the damage based on radius
        Vector3 distanceVector = gm.transform.position - transform.position;
        if (!Physics2D.Raycast(transform.position, distanceVector, radius, mask))
        {
            float scaledDamage = damage * (1 - (distanceVector.magnitude / radius));

            Debug.Log("Taking " + (int)scaledDamage + " Damage");

            hp.TakeDamage((int)scaledDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
