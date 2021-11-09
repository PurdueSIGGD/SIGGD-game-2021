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

    // Equips a new item (dequipping and returning any old/extra item)
    public GameObject EquipItem(GameObject newItem, bool invokeEvent = true)
    {
        // Merge items if possible
        if (Mergeable(equippedItem, newItem))
        {
            GameObject srcItem = MergeItem(equippedItem, newItem);
            if (invokeEvent)
            {
                onItemChange.Invoke();
            }
            return srcItem;
        }

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

    // Check if two objects are mergeable
    public bool Mergeable(GameObject dest, GameObject src)
    {
        return (dest.name == src.name && dest.GetComponent<Stackable>() && src.GetComponent<Stackable>());
    }

    // Merge src onto dest if possible (returning what remains in src)
    public GameObject MergeItem(GameObject dest, GameObject src)
    {
        // Don't merge items if they aren't the same name
        if (dest.name != src.name)
        {
            return src;
        }

        // Merge two stackable items
        if (dest.GetComponent<Stackable>())
        {
            Stackable destStack = dest.GetComponent<Stackable>();
            Stackable srcStack = src.GetComponent<Stackable>();

            int diff = destStack.AddToStack(srcStack.count);
            if (diff == 0)
            {
                srcStack = null;
            } else
            {
                srcStack.count = diff;
            }
        }

        return src;
    }
}
