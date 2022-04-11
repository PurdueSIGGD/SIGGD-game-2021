using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : Trigger
{
    [SerializeField] private Health characterHealth;
    private int lastHealth = 0;

    private void Start()
    {
        lastHealth = characterHealth.GetMaxHealth();
    }

    public override bool isActive()
    {
        if (characterHealth.GetCurrHealth() < lastHealth)
        {
            lastHealth = characterHealth.GetCurrHealth(); 
            //^This line makes it so MarkHealth dies not need ot be called before every check, we can remove later if needed
            return true;
        }

        return false;
    }

    public void MarkHealth()
    {
        lastHealth = characterHealth.GetCurrHealth();
    }
}