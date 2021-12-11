using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 velocity;

    private Transform postiion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        postiion = GetComponent<Transform>();
        Vector2 deltaVeloctiy = velocity * Time.deltaTime;
        postiion.position += new Vector3(deltaVeloctiy.x, deltaVeloctiy.y, 0);
    }
    void FixedUpdate()
    {
        
    }
}
