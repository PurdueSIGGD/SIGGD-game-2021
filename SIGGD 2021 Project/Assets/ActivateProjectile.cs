using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;

    public void activate(Vector2 velocity)
    {
        this.velocity = velocity;
        this.GetComponent<Projectile>().enabled = true;
    }  //Script to set projectile's velocity and activate it

    public Vector2 getVelocity()
    {
        return velocity;
    }  //For the "Projectile" script to access velocity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
