using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    Attack attack;
    Movement movement;
    SpriteRenderer spriteRenderer;

    public Sprite idleSprite;
    public Sprite sneakSprite;
    public Sprite walkSprite;
    public Sprite runSprite;
    public Sprite attackSprite;

    bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting sprites based on player movement and attacking
        if (attack.isAttacking()) {
            spriteRenderer.sprite = attackSprite;
        }
        else if (movement.isRunning()) 
        {
            spriteRenderer.sprite = runSprite;   
        } 
        else if (movement.isSneaking()) 
        {
            spriteRenderer.sprite = sneakSprite;
        } 
        else if (movement.isMoving()) 
        {
            spriteRenderer.sprite = walkSprite;
        } 
        else 
        {
            spriteRenderer.sprite = idleSprite;
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