using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stackable : MonoBehaviour, ICanUse
{
    // Variables to dictate the maximum size of the stack
    public int count;
    public int max;

    // Called by the use event, decrements the stack
    public void UseItem() {
        count -= 1;
        if (count <= 0) {
            count = 0;

            // Code to delete an item when its stack runs out
            GameObject.FindWithTag("Player").GetComponentInChildren<Inventory>().DequipItem();
            Destroy(gameObject);
        }
    }

    // Whether this item can be used
    public bool CanUse() {
        return count > 0;
    }

    // Adds n items to the stack, returning the amount of items beyond the max (or 0)
    public int AddToStack(int n)
    {
        if (count + n <= max)
        {
            count += n;
            return 0;
        } else
        {
            int diff = (count + n) - max;
            count = max;
            return diff;
        }
    }
}
