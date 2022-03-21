using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private Transform direction;
    [SerializeField] private GameObject gameObject;

    void Start()
    {
        location = this.transform.parent.parent;
        direction = this.transform.parent.parent.GetChild(1);
    }

    public void spawnProjectile()
    {
        GameObject newObj = GameObject.Instantiate(gameObject, location.position, Quaternion.identity);
        Vector2 velocity = direction.position - location.position;
        newObj.GetComponent<ActivateProjectile>().activate(velocity.normalized);
    }
    //Spawns projectile, set its velocity, then activate the projectile script (in this order)
}
