using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public KeyCode useKey = KeyCode.F;
    public KeyCode dropKey = KeyCode.Q;

    // Event to be called right after the item in the inventory is changed
    public StringGameEvent onItemChange;

    // Currently equipped item
    public GameObject equippedItem;

    // Scripts for using and dropping the current item
    private Timer useItemTimer;
    private bool useItemReady = true;

    private void Start()
    {
        useItemTimer = GetComponent<Timer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(useKey) && useItemReady)
        {
            useItemReady = false;
            useItemTimer.StartTimer();

            // Use the item
            if (equippedItem) UseItem();
        }

        if (Input.GetKeyUp(useKey))
        {
            if (equippedItem) EndUseItem();
        }

        if (Input.GetKeyDown(dropKey) && useItemReady)
        {
            useItemReady = false;
            useItemTimer.StartTimer();

            // Drop the item (using the same timer)
            if (equippedItem) dropItem(transform.position);

            UpdateUI();
        }
    }
    public void RefreshItemUse()
    {
        useItemReady = true;
    }

    // Uses the current item
    public void UseItem()
    {
        if (!equippedItem) return;

        ItemControl currentControl = equippedItem.GetComponent<ItemControl>();
        currentControl.use.Invoke();
    }

    // Stops using the current item
    public void EndUseItem()
    {
        if (!equippedItem) return;

        ItemControl currentControl = equippedItem.GetComponent<ItemControl>();
        currentControl.endUse.Invoke();
    }

    // Equips a new item (dequipping and returning any old/extra item)
    public void EquipItem(GameObject itemPickup)
    {
        // Merge items if possible
        if (canMerge(itemPickup))
        {
            // equip by merging stack counts into equipped item
            itemPickup.GetComponent<ItemPickupCount>()
                .MergeToStack(
                    this.equippedItem.GetComponent<Stackable>()
                );
        } else {
            equipSwapOut(itemPickup);
        }

        UpdateUI();
    }

    // mergeable if item id matches and proper components not null
    private bool canMerge(GameObject itemPickup) {
        if (this.equippedItem == null) return false;

        var stackComp = this.equippedItem.GetComponent<Stackable>();
        var itemPickupCountComp = itemPickup.GetComponent<ItemPickupCount>();

        return ItemMeta.HasSameItemID(this.equippedItem, itemPickup) 
                && stackComp != null && itemPickupCountComp != null;
    }


    // equip by dequipping current item and equipping new instantiated one
    private void equipSwapOut(GameObject itemPickup) {
        if (equippedItem) {
            dropItem(itemPickup.transform.position);
        }

        this.equippedItem = itemPickup.GetComponent<ItemMeta>()
            .BuildSystemPrefab(this.transform);


        Destroy(itemPickup);
        
        this.equippedItem.GetComponent<ItemControl>()
            .equip.Invoke();
    }

    public void DropItem() {
        dropItem(this.transform.position);

        UpdateUI();
    }

    // Dequips and returns the current item (parent must be set by whatever else)
    private void dropItem(Vector3 dropLocation)
    {
        var nullableCount = this.equippedItem.GetComponent<Stackable>()?.count;
        if (nullableCount != 0) {
            this.equippedItem.GetComponent<ItemMeta>()
                .BuildPickupPrefab(dropLocation, nullableCount);
        }

        equippedItem.GetComponent<ItemControl>()
            .dequip.Invoke();
        Destroy(equippedItem);
        equippedItem = null;
    }

    public void UpdateUI()
    {
        if (equippedItem)
        {
            equippedItem.GetComponent<ItemMeta>().SendIDEvent(onItemChange);
        } else
        {
            onItemChange.Invoke(null);
        }

    }

    public bool IsValidItemPickup(GameObject gObj) =>
        gObj.GetComponent<ItemMeta>() != null
        && gObj.GetComponent<ItemControl>() == null;

    // This is called by the interaction unity event
    public void handleInteraction(GameObject gameObj) {
        if (IsValidItemPickup(gameObj)) {
            EquipItem(gameObj);
        }

        IdCheck idCheck = gameObj.GetComponent<IdCheck>();
        idCheck?.CheckId(ItemMeta.GetID(equippedItem));
        // Call checkId event with the item's id (multiple keycards have different IDs)
        //id?.CheckId(equippedItem.GetComponent<ItemMeta>().id)
    }
}
