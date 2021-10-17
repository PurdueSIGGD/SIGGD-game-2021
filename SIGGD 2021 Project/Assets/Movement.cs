using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidbody;

    public CircleCollider2D soundHitbox;

    public Transform attackHitbox;

    Vector2 movement;
    Vector2 old_pos;
    Vector2 new_pos;
    Vector2 point;

    public double velocity;

    void Start()
    {
        old_pos = GetComponent<Rigidbody>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 unitMovement = movement.normalized;
        GetComponent<Rigidbody>().MovePosition((Vector2)GetComponent<Rigidbody>().position + unitMovement * moveSpeed * Time.fixedDeltaTime);
        new_pos = GetComponent<Rigidbody>().position;

        velocity = Vector2.Distance(old_pos, new_pos) / Time.fixedDeltaTime;

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

        if (velocity != 0)
        {
            soundHitbox.radius = moveSpeed;
            
        }
        else
        {
            soundHitbox.radius = 0;
        }

        if ((movement.x != 0) || (movement.y != 0))
        {
            float x = GetComponent<Rigidbody>().position.x + unitMovement.x * 0.65f;
            float y = GetComponent<Rigidbody>().position.y + unitMovement.y * 0.65f;
            attackHitbox.position = new Vector2(x,y);
        }

        old_pos = GetComponent<Rigidbody>().position;
    }
}
