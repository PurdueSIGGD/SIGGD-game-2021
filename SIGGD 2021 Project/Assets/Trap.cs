using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private TrapTriggered parentTrigger;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive && other.name.Equals("Player"))
        {
            isActive = false;
            parentTrigger.getBehavior().setDestination(this.GetComponent<Transform>());
            parentTrigger.setTrigger(true);
            Debug.Log("Stepped on trap");
        }
    }

    public void reActivate()
    {
        isActive = true;
    }
}
