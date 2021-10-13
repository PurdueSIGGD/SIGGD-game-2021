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
    private int currHealth;
    [SerializeField] private UnityEvent healthChangeEvent;
    [SerializeField] private UnityEvent deathEvent;
    private bool dead = false;

    private void Start()
    {
        currHealth = maxHealth;
    }

    //takes damage and/or heals if the damage is negative also invokes the death event when health is <= 0
    public void TakeDamage(int damage)
    {
        if (dead)
        {
            return;
        }

        currHealth -= damage;
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

    //returns whether the health is <= 0
    public bool IsDead()
    {
        return currHealth <= 0;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrHealth()
    {
        return currHealth;
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
