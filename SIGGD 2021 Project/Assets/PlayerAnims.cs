using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    [SerializeField] private Attack attack;
    [SerializeField] private Movement movement;
    [SerializeField] private Animator animator;

    [SerializeField] private string idle;
    [SerializeField] private string sneak;
    [SerializeField] private string walk;
    [SerializeField] private string run;
    [SerializeField] private string attacking;

    bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting sprites based on player movement and attacking
        if (attack.isAttacking()) {
            animator.Play(attacking);
        }
        else if (movement.isRunning()) 
        {
            animator.Play(run);
        } 
        else if (movement.isSneaking()) 
        {
            animator.Play(sneak);
        } 
        else if (movement.isMoving()) 
        {
            animator.Play(walk);
        } 
        else 
        {
            animator.Play(idle);
        }
    }
}