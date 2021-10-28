using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;

    public CircleCollider2D soundHitbox;

    public Transform attackHitbox;

    Vector2 movement;
    Vector2 old_pos;
    Vector2 new_pos;
    Vector2 point;

    void Start()
    {
        old_pos = GetComponent<Rigidbody2D>().position;
        soundHitbox = GetComponent<CircleCollider2D>();
        attackHitbox = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

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
        new_pos = rigidBody.position;

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
            attackHitbox.position = new Vector2(rigidBody.position.x, rigidBody.position.y);
        } 
        else 
        {
            soundHitbox.radius = 0;
        }

        old_pos = rigidBody.position;
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