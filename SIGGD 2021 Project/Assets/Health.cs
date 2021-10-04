using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/**
 * Health.cs
 * 
 * An object that stores and manages functions related to modifying health values.
 * 
 * @author Joseph Miller
 * @version October 1, 2021
 */

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currHealth;
    [SerializeField] private UnityEvent deathEvent;

    //takes damage and/or heals if the damage is positive also invokes the death event
    public void TakeDamage(int damage)
    {
        currHealth -= damage;
        if (this.IsDead())
        {
            this.currHealth = 0;
            deathEvent.Invoke();
            Debug.Log("The enemy is dead");
        }
    }

    //returns whether the health is > 0
    public bool IsDead()
    {
        if (currHealth <= 0)
            return true;
        return false;
    }

    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

    public int GetCurrHealth()
    {
        return this.currHealth;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void SetCurrHealth(int currHealth)
    {
        this.currHealth = currHealth;
    }
}
