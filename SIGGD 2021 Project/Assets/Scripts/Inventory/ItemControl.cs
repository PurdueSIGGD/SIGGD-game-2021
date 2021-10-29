using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemControl : MonoBehaviour
{
    public UnityEvent use;
    public UnityEvent equip;
    public UnityEvent dequip;

    public bool canUse() {
        // all components must be true to return true
        foreach (var comp in GetComponentsInChildren<ICanUse>()) {
            if (comp.canUse() == false) {
                return false;
            }
        }

        return true;
    }
}

public interface ICanUse {
    bool canUse();
}