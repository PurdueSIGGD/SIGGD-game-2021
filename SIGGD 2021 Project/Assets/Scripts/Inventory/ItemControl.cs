using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemControl : MonoBehaviour
{
    public UnityEvent use;
    public UnityEvent equip;
    public UnityEvent dequip;

    public bool CanUse() {
        // all components must be true to return true
        foreach (var comp in GetComponentsInChildren<ICanUse>()) {
            if (comp.CanUse() == false) {
                return false;
            }
        }

        return true;
    }

    public void UseItem()
    {
        // all components get used (decrement stack, etc)
        foreach (var comp in GetComponentsInChildren<ICanUse>())
        {
            comp.UseItem();
        }
    }
}

public interface ICanUse {
    bool CanUse();
    void UseItem();
}