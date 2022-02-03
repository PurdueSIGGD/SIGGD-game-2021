using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemMeta))]
public class ItemPickupCount : MonoBehaviour
{
    [field: Range(1, 9)]
    [field: SerializeField] 
    public int count {get; set;} = 1;

    public void MergeToStack(Stackable stack) {
        this.count = stack.AddToStack(this.count);
        if (this.count == 0) {
            Destroy(gameObject);
        }
    }
}
