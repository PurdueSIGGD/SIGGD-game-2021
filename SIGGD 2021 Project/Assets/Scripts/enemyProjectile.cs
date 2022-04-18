using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [HideInInspector] public int damage = 1;
    [SerializeField] public GameObject breakIcon;

    private void Start()
    {
        if (breakIcon != null)
        {
            GameObject g = Instantiate(breakIcon, transform.position, transform.rotation);
            Destroy(g, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
