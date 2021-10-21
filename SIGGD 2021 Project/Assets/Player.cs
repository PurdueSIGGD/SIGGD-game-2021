using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Movement movement;
    SpriteRenderer spriteRenderer;

    public Sprite idle;
    public Sprite sneak;
    public Sprite walk;
    public Sprite run;
    public Sprite attack;

    bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting sprites based on player movement
        if (movement.isRunning()) 
        {
            spriteRenderer.sprite = run;   
        } 
        else if (movement.isSneaking()) 
        {
            spriteRenderer.sprite = sneak;
        } 
        else if (movement.isMoving()) 
        {
            spriteRenderer.sprite = walk;
        } 
        else 
        {
            spriteRenderer.sprite = idle;
        }

        // Flipping sprites based on player movement direction
        if (movement.isMovingRight() && !isFacingRight) 
        {
            spriteRenderer.flipX = true;
            isFacingRight = true;
        } 
        else if (movement.isMovingLeft() && isFacingRight) 
        {
            spriteRenderer.flipX = false;
            isFacingRight = false;
        }
    }
}