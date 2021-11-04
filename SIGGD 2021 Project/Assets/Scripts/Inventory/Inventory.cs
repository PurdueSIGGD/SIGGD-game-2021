using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    // Event to be called right after the item in the inventory is changed
    public UnityEvent onItemChange;

    // Currently equipped item
    public GameObject equippedItem;

    // Uses the current item
    public void UseItem()
    {
        ItemControl currentControl = equippedItem.GetComponent<ItemControl>();
        currentControl.use.Invoke();
    }

    // Equips a new item (dequipping and returning any old item)
    public GameObject EquipItem(GameObject newItem, bool invokeEvent = true)
    {
        // Dequip the current item (if any) and avoid triggering the event twice
        GameObject copyItem = equippedItem;
        if (equippedItem != null)
        {
            copyItem = DequipItem(false);
        }

        // Equip the new item
        ItemControl newItemControl = newItem.GetComponent<ItemControl>();
        equippedItem = copyItem;
        newItemControl.equip.Invoke();

        if (invokeEvent)
        {
            onItemChange.Invoke();
        }

        return copyItem;
    }

    // Dequips and returns the current item
    public GameObject DequipItem(bool invokeEvent = true)
    {
        ItemControl currentControl = equippedItem.GetComponent<ItemControl>();
        currentControl.dequip.Invoke();
        GameObject copyItem = equippedItem;
        equippedItem = null;

        if (invokeEvent)
        {
            onItemChange.Invoke();
        }

        return copyItem;
    }
}
