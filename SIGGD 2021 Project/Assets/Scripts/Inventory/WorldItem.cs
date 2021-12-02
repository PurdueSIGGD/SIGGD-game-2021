using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    private GameObject invItem;
    private Inventory playerInv;
    private Collider2D hitbox;

    public void Start()
    {
        playerInv = GameObject.FindWithTag("Player").GetComponentInChildren<Inventory>();
        hitbox = GetComponent<Collider2D>();

        SetItem(transform.GetChild(0).gameObject);
    }

    public void SetItem(GameObject value)
    {
        // Set Item
        invItem = value;
        value.transform.SetParent(transform);
        value.transform.localPosition = Vector3.zero;
        if (value.GetComponent<SpriteRenderer>()) value.GetComponent<SpriteRenderer>().enabled = false;

        // Set Sprite
        ItemSprite spr = value.GetComponent<ItemSprite>();
        GetComponent<SpriteRenderer>().sprite = spr.GetWorldSprite();

        // Set Collider Size
        if (hitbox is CircleCollider2D hbc)
        {
            hbc.radius = ((spr.spriteSize.x + spr.spriteSize.y) / 4f) / 32f;
        } else if (hitbox is BoxCollider2D hbb)
        {
            hbb.size = (spr.spriteSize) / 32f;
        }
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
            // This item has been picked up, it can be removed (the item should have already been destroyed)
            Destroy(this.gameObject);
        } else
        {
            // Something else has been dropped
            SetItem(changeItem);
        }
    }
}
