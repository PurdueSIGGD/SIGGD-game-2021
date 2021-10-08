using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int damageTaken;
    public int healthRestored;
    public Material blankMaterialRef; // Color of the heart when taken damage
    public Material redMaterialRef; // Color of the heart when full
    public int healthRemaining = 3;
    public bool playerAlive = true;
    public int maxHealth = 3;

    public GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive)
        {
            HealthToSee();
        }
        else
        {
            // Death event
        }
    }

    public void HealthToSee()
    {
        for (int i = damageTaken; i > 0; i--)
        {
            healthRemaining = healthRemaining - 1;
            hearts[healthRemaining].GetComponent<Renderer>().material = blankMaterialRef;
            damageTaken--;
        }

        for (int i = healthRestored; i > 0; i--)
        {
            if (healthRemaining != maxHealth)
            {
                hearts[healthRemaining].GetComponent<Renderer>().material = redMaterialRef;
                healthRemaining = healthRemaining + 1;
                healthRestored--;
            }   
        }

        if(healthRemaining == 0)
        {
            playerAlive = false;
        }
    }
}