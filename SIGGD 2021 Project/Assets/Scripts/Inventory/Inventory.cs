using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    // Event to be called when the item in the inventory is changed
    public UnityEvent onItemChange;

    // Currently equipped item
    public GameObject equippedItem;

    
}
