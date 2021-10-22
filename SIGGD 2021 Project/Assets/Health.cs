using UnityEngine;
using UnityEngine.Events;

/**
 * Health.cs
 * 
 * An object that stores and manages functions related to modifying health values.
 * 
 * @author Joseph Miller, Ahmet Oguz
 */

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currHealth;
    [SerializeField] private UnityEvent healthChangeEvent;
    [SerializeField] private UnityEvent deathEvent;
    private bool dead = false;

    private void Start()
    {
        this.currHealth = this.maxHealth;
        Debug.Log("Current Health: " + this.currHealth + "set to max Health: " + this.maxHealth);
    }

    //takes damage and/or heals. if the damage is negative also invokes the death event when health is <= 0
    public void TakeDamage(int damage)
    {
        Debug.Log("damage taken:" + damage + " CurrHealth:" + this.currHealth);
        if (dead)
        {
            return;
        }

        this.currHealth -= damage;
        if (healthChangeEvent != null)
        {
            healthChangeEvent.Invoke();
        }
        
        if (IsDead())
        {
            currHealth = 0;
            if (deathEvent != null)
            {
                deathEvent.Invoke();
            }
            Debug.Log(string.Format("{0} is dead", name));
            dead = true;
        }
    }

    // Code ran when dead
    public void Die()
    {
        Debug.Log("Dying...");
    }

    //returns whether the health is <= 0
    public bool IsDead()
    {
        return this.currHealth <= 0;
    }

    public int GetMaxHealth()
    {
        return this.maxHealth;
    }

    public int GetCurrHealth()
    {
        return this.currHealth;
    }

    //sets max and current health (minimum = 1)
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        if (this.maxHealth < 1)
        {
            this.maxHealth = 1;
        }
        currHealth = maxHealth;
        if (healthChangeEvent != null)
        {
            healthChangeEvent.Invoke();
        }
    }

    //sets current health (minimum = 1, maximum = maxHealth)
    public void SetCurrHealth(int currHealth)
    {
        this.currHealth = currHealth;
        if (this.currHealth > maxHealth)
        {
            this.currHealth = maxHealth;
        }
        if (this.currHealth < 1)
        {
            this.currHealth = 1;
        }
        if (healthChangeEvent != null)
        {
            healthChangeEvent.Invoke();
        }
    }
}
