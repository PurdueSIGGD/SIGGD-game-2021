using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerMeter : MonoBehaviour, ICanUse
{
    // Power tracking variables
    public float maxPower;
    public float currentPower;

    // Two modes of power consumption: continuous while button held, or single amount.
    public float powerPerSecond;
    public float powerFlatCost;

    // Event to be called when consumption is stopped or started (to turn on or off the effect)
    // stopConsuming is also called when power runs out
    public UnityEvent startConsumingEvent;
    public UnityEvent stopConsumingEvent;

    // GameEvent to be called for UI purposes
    public FloatGameEvent uiEvent;

    protected bool isConsumingPower = false;

    public virtual void FixedUpdate()
    {
        if (isConsumingPower)
        {
            ConsumePower(powerPerSecond * Time.deltaTime);
        }

        uiEvent.Invoke(currentPower / maxPower);
    }

    public void ConsumePower(float amountToConsume)
    {
        currentPower = Mathf.Clamp(currentPower - amountToConsume, 0f, maxPower);
        if (currentPower == 0f)
        {
            StopConsuming();
        }
    }

    public void AddPower(float amountToAdd)
    {
        ConsumePower(-amountToAdd);
    }

    public void ConsumeFlatPowerCost()
    {
        ConsumePower(powerFlatCost);
    }

    public virtual void StartConsuming()
    {
        isConsumingPower = true;
        startConsumingEvent.Invoke();
    }

    public virtual void StopConsuming()
    {
        isConsumingPower = false;
        stopConsumingEvent.Invoke();
    }

    public void ToggleConsumption()
    {
        if (isConsumingPower)
        {
            StopConsuming();
        } else
        {
            StartConsuming();
        }
    }

    public bool CanUse()
    {
        return currentPower > 0f;
    }
}
