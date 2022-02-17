using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour, ICanUse
{
    public Timer cooldownTimer;

    private void Start()
    {
        if (cooldownTimer == null)
        {
            cooldownTimer = GetComponent<Timer>();
        }
    }

    public void StartCooldown()
    {
        cooldownTimer.StartTimer();
    }

    public bool CanUse()
    {
        return (bool)(cooldownTimer?.IsFinished());
    }
}
