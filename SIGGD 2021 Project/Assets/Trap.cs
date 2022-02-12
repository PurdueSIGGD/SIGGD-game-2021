using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // set this to the TrapTriggered script of the parent
    [SerializeField] private TrapTriggered parentTrigger;
    private bool isActive; //is the trap active

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // checks if it's the player who steps on the trap
        if ((isActive && other.name.Equals("Player")))
        {
            isActive = false;

            // set trigger to true and pass this trap's transform to ApproachTrap behavior.
            parentTrigger.getBehavior().setDestination(this.GetComponent<Transform>());
            parentTrigger.setTrigger(true);
        }
    }

    public void reActivate()
    {
        isActive = true;
    }
}
