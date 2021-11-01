using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour, ICanUse
{
    public int count;

    public void UseItem() {
        count -= 1;
        if (count < 0) {
            count = 0;
        }
    }

    public bool CanUse() {
        return count > 0;
    }
}
