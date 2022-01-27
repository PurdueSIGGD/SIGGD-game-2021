using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private Transform direction;
    [SerializeField] private GameObject gameObject;

    public void spawnProjectile()
    {
        GameObject newObj = GameObject.Instantiate(gameObject, location.position, Quaternion.identity);
        Vector2 velocity = direction.position - location.position;
        newObj.GetComponent<ActivateProjectile>().activate(velocity.normalized);
    }
    //Spawns projectile, set its velocity, then activate the projectile script (in this order)
}
