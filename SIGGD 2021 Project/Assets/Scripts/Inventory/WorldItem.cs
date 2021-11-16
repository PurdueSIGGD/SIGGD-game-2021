using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [SerializeField]
    public GameObject invItem;

    private Inventory playerInv;
    public void Start()
    {
        playerInv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        SetItem(invItem);
    }

    public void SetItem(GameObject value)
    {
        invItem = value;
        GetComponent<SpriteRenderer>().sprite = value.GetComponent<ItemSprite>().GetWorldSprite();
    }

    // Adds the worldItem's inventory item to a target inventory (no parameter is the player's)
    public void PickupItem()
    {
        PickupItem(playerInv);
    }
    public void PickupItem(Inventory target)
    {
        GameObject changeItem = target.EquipItem(invItem);
        if (changeItem == null)
        {
            // This item has been picked up, it can be removed
            Destroy(this);
        } else
        {
            // Something else has been dropped
            SetItem(changeItem);
        }
    }
}
