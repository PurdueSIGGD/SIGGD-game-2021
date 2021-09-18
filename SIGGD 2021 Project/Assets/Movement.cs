using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidbody;

    public CircleCollider2D soundHitbox;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        soundHitbox.radius = rigidbody.velocity.magnitude;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 8f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
}
