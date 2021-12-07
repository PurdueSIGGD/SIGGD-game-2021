using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    // Event to be called right after the item in the inventory is changed
    public UnityEvent onItemChange;

    // Currently equipped item
    public GameObject equippedItem;

    // Scripts for using and dropping the current item
    private Timer useItemTimer;
    private bool useItemReady = true;

    [SerializeField] private StringToPrefabScriptable idToItemSystemPrefab;
    [SerializeField] private StringToPrefabScriptable idToItemPickupPrefab;

    private void Start()
    {
        useItemTimer = GetComponent<Timer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && useItemReady)
        {
            useItemReady = false;
            useItemTimer.StartTimer();

            // Use the item
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.Q) && useItemReady)
        {
            useItemReady = false;
            useItemTimer.StartTimer();

            // Drop the item (using the same timer)
            DequipItem(transform.position, true);
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
        onItemChange?.Invoke();
    }

    // Equips a new item (dequipping and returning any old/extra item)
    public void EquipItem(GameObject itemPickup, bool invokeEvent = true)
    {
        // Merge items if possible
        if (this.equippedItem != null)
        {
            var stack = this.equippedItem.GetComponent<Stackable>();
            var itemPickupCountComp = itemPickup.GetComponent<ItemPickupCount>();

            // mergeable if item id matches and proper components not null
            if (itemIDMatches(itemPickup) && stack != null && itemPickupCountComp != null) {
                itemPickupCountComp.MergeToStack(stack);
                if (invokeEvent)
                {
                    onItemChange?.Invoke();
                }
                return;
            }
        }

        createAndEquipItemSystemFromPickup(itemPickup);

        if (invokeEvent)
        {
            onItemChange?.Invoke();
        }
    }

    private void createAndEquipItemSystemFromPickup(GameObject itemPickup) {
        // Dequip the current item (if any) and avoid triggering the event twice
        if (equippedItem) {
            DequipItem(itemPickup.transform.position, false);
        }

        // instantiate prefab via pickup's id
        var itemPickupID = itemPickup.GetComponent<ItemID>().id;
        this.equippedItem = Instantiate(this.idToItemSystemPrefab.getPrefab(itemPickupID));
        this.equippedItem.transform.SetParent(transform);

        // set stack count to item pickup count (if these components exist)
        {
            var stack = this.equippedItem.GetComponent<Stackable>();
            var itemPickupCountComp = itemPickup.GetComponent<ItemPickupCount>();

            if (stack != null && itemPickupCountComp != null) {
                stack.SetStack(0);
                itemPickupCountComp.MergeToStack(stack);
            }
        }

        
        var itemControl = this.equippedItem.GetComponent<ItemControl>();
        itemControl.equip.Invoke();
    }

    public void DequipItem() {
        DequipItem(this.transform.position, true);
    }

    // Dequips and returns the current item (parent must be set by whatever else)
    private void DequipItem(Vector3 dropLocation, bool invokeEvent = true)
    {
        var equippedItemID = this.equippedItem.GetComponent<ItemID>().id;

        // instantiate item pickup from equipped item's id
        var itemPickup = Instantiate(this.idToItemPickupPrefab.getPrefab(equippedItemID));
        itemPickup.transform.position = dropLocation;

        // set item pickup count to equipped item count (if components exist)
        {
            var itemPickupCountComp = itemPickup.GetComponent<ItemPickupCount>();
            var equippedItemStack = this.equippedItem.GetComponent<Stackable>();

            if (itemPickupCountComp != null && equippedItemStack != null) {
                itemPickupCountComp.count = equippedItemStack.count;
            }
        }

        var currentControl = equippedItem.GetComponent<ItemControl>();
        currentControl.dequip.Invoke();

        equippedItem = null;

        if (invokeEvent)
        {
            onItemChange?.Invoke();
        }
    }

    public bool itemIDMatches(GameObject itemPickup) 
        => this.equippedItem.GetComponent<ItemID>().id
            .Equals(itemPickup.GetComponent<ItemID>().id);

    public bool IsValidItemPickup(GameObject gObj) =>
        gObj.GetComponent<ItemID>() != null
        && gObj.GetComponent<ItemControl>() == null;

    public void handleInteraction(GameObject gameObj) {
        if (IsValidItemPickup(gameObj)) {
            EquipItem(gameObj);
        }
    }
}
