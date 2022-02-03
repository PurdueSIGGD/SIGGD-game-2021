using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Trigger trapTrigger;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (isActive && other.name.Equals("Player"))
        {
            isActive = false;

        }
    }

    public void reActivate()
    {
        isActive = true;
    }
}
