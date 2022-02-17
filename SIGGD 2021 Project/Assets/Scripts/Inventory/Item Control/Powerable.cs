using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerable : MonoBehaviour, ICanUse
{
    // Power tracking variables
    public float maxPower;
    public float currentPower;

    // Two modes of power consumption: continuous while button held, or single amount.
    public float powerPerSecond;
    public float powerFlatCost;

    private bool isConsumingPower;
    private ItemControl ic;

    private void Start()
    {
        ic = GetComponent<ItemControl>();
    }

    private void FixedUpdate()
    {
        if (isConsumingPower)
        {
            ConsumePower(powerPerSecond * Time.deltaTime);
        }
    }

    public void ConsumePower(float amountToConsume)
    {
        currentPower = Mathf.Clamp(currentPower - amountToConsume, 0, maxPower);
        if (currentPower == 0f)
        {
            ic.endUse.Invoke();
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

    public void StartConsuming()
    {
        if (isConsumingPower) return;
    }

    public void StopConsuming()
    {
        if (!isConsumingPower) return;
    }

    public bool CanUse()
    {
        return currentPower > 0f;
    }
}
