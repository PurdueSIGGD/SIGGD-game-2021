using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rigidBody;

    public CircleCollider2D soundHitbox;

    public Vector2 movement;

    private Transform interactHitbox;
    private Transform attackHitbox;

    [SerializeField] private bool crouchToggle = false;

    private void Start()
    {
        interactHitbox = transform.GetChild(1);
        attackHitbox = transform.GetChild(0);
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

        // Update facing angle
        if (movement.magnitude > 0.2f)
        {
            //facing = unitMovement;
            Vector3 hitboxPosition = transform.position + new Vector3(unitMovement.x, unitMovement.y) * 0.5f;
            interactHitbox.position = hitboxPosition;
            attackHitbox.position = hitboxPosition;
        }

        if (isRunning())
        {
            moveSpeed = 8f;
        }
        else if (isSneaking())
        {
            moveSpeed = 3f;
        }
        else
        {
            moveSpeed = 5f;
        }

        if (isMoving())
        {
            soundHitbox.radius = Mathf.Lerp(soundHitbox.radius + Random.Range(0f, moveSpeed / 16), moveSpeed, Time.deltaTime*8);
            float angle = 0;
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                if (movement.x > 0)
                {
                    angle = -90;
                } else
                {
                    angle = 90;
                }
            } else
            {
                if (movement.y > 0)
                {
                    angle = 0;
                }
                else
                {
                    angle = 180;
                }
            }
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //attackHitbox.position = new Vector2(rigidBody.position.x, rigidBody.position.y) + facing * 0.5f;
            //interactHitbox.position = new Vector2(rigidBody.position.x, rigidBody.position.y) + facing * 0.5f;
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            crouchToggle = !crouchToggle;
        }
        return Input.GetKey(KeyCode.LeftControl) || crouchToggle;
    }

    public bool isMoving() {
        return (movement.x != 0) || (movement.y != 0);
    }
}