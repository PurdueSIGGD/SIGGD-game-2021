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
    // DO NOT CHANGE currHealth OUTSIDE OF THE SET METHOD
    private int currHealth = 0; // changed at start method
    [SerializeField] private UnityEvent<int> healthChangeEvent;
    [SerializeField] private UnityEvent deathEvent;

    private void Start()
    {
        SetCurrHealth(maxHealth);
    }

    //takes damage and/or heals if the damage is negative also invokes the death event when health is <= 0
    public void TakeDamage(int damage)
    {
        if (IsDead())
        {
            return;
        }

        SetCurrHealth(currHealth - damage);
        
        if (IsDead())
        {
            deathEvent?.Invoke();
            Debug.Log(string.Format("{0} is dead", name));
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
        this.maxHealth = Mathf.Clamp(maxHealth, 1, int.MaxValue);
        SetCurrHealth(this.maxHealth);
    }

    //sets current health (minimum = 1, maximum = maxHealth)
    public void SetCurrHealth(int currHealth)
    {
        int newHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        if (this.currHealth != newHealth) 
        {
            this.currHealth = newHealth;
            healthChangeEvent?.Invoke(this.currHealth);
        }
    }
}
