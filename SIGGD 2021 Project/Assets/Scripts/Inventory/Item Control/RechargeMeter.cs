using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeMeter : PowerMeter
{
    // PowerMeter except it recharges an amount per second
    public float rechargePerSecond;

    private bool recharging = true;

    // Timer to set a "cooldown period"
    public Timer rechargeCooldown;

    public override void FixedUpdate()
    {
        if (!isConsumingPower && recharging)
        {
            // Recharge while not consuming power
            ConsumePower(-rechargePerSecond * Time.deltaTime);
        }
        base.FixedUpdate();
    }

    // Disable recharge when consumption happens
    public override void StartConsuming()
    {
        base.StartConsuming();
        StopRecharge();
    }

    // Re-enable recharge (or start the timer) when consumption stops
    public override void StopConsuming()
    {
        base.StopConsuming();
        if (rechargeCooldown)
        {
            rechargeCooldown.StartTimer();
        } else
        {
            StartRecharge();
        }
    }

    // Public functions so events can interact with them
    public void StartRecharge()
    {
        recharging = true;
    }
    public void StopRecharge()
    {
        recharging = false;
    }
}
