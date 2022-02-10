using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemControl : MonoBehaviour
{
    public UnityEvent use;
    public UnityEvent equip;    // Called right after the inventory equips the item
    public UnityEvent dequip;   // Called right before the inventory dequips the item

    // Derender sprite (remove this if the item system will appear in the world)
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool CanUse() {
        // all components must be true to return true
        foreach (var comp in GetComponentsInChildren<ICanUse>()) {
            if (comp.CanUse() == false) {
                return false;
            }
        }

        return true;
    }
}

public interface ICanUse {
    bool CanUse();
}