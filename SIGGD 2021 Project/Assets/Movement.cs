using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rigidBody;

    public CircleCollider2D soundHitbox;

    public Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Move the player
        Vector2 unitMovement = movement.normalized;
        rigidBody.MovePosition(rigidBody.position + unitMovement * moveSpeed * Time.fixedDeltaTime);

        // Update facing angle
        //if (movement.magnitude > 0.2f)
        //{
        //    facing = unitMovement;
        //}

        if (isRunning())
        {
            moveSpeed = 8f;
        }
        else if (isSneaking())
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = 5f;
        }

        if (isMoving())
        {
            soundHitbox.radius = moveSpeed;
        } 
        else 
        {
            soundHitbox.radius = 0;
        }

    }

    public bool isRunning() {
        return Input.GetKey(KeyCode.LeftShift);
    } 

    public bool isSneaking() {
        return Input.GetKey(KeyCode.LeftControl);
    }

    public bool isMoving() {
        return (movement.x != 0) || (movement.y != 0);
    }

    public bool isMovingRight() {
        return movement.x > 0;
    }

    public bool isMovingLeft() {
        return movement.x < 0;
    }
}