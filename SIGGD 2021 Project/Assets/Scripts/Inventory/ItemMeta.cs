using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMeta : MonoBehaviour
{
    [SerializeField] private string id = "UNSET_ITEM_ID";
    private static IDToItemPrefabs _mappings;
    public static IDToItemPrefabs mappings {
        get {
            _mappings ??= Resources.Load<IDToItemPrefabs>("Mappings/ID To Item Prefabs");
            return _mappings;
        }
    }

    public GameObject BuildSystemPrefab(Transform systemParent) {
        var systemInstance = Instantiate(mappings.get(this.id).system, systemParent);
        systemInstance.transform.SetParent(systemParent);

        // copy this component into the system instance
        var sysInstMeta = systemInstance.AddComponent<ItemMeta>();
        sysInstMeta.id = this.id;

        var stackComp = systemInstance.GetComponent<Stackable>();
        // Do not use prefab's itempickupcount component
        var selfPickupCountComp = GetComponent<ItemPickupCount>();

        if (stackComp != null && selfPickupCountComp != null) {
            stackComp.SetStack(0);
            selfPickupCountComp.MergeToStack(stackComp);
        }

        return systemInstance;
    }
    public GameObject BuildPickupPrefab(Vector3 dropLocation, int? newPickupCount) {
        var pickupInstance = Instantiate(mappings.get(this.id).pickup);
        pickupInstance.transform.position = dropLocation;

        var itemPickupCountComp = pickupInstance.GetComponent<ItemPickupCount>();

        if (itemPickupCountComp != null && newPickupCount != null) {
            itemPickupCountComp.count = newPickupCount.Value;
        }

        return pickupInstance;
    }

    public void SendIDEvent(StringGameEvent gameEvent)
    {
        gameEvent.Invoke(this.id);
    }

    public static bool HasSameItemID(GameObject a, GameObject b) {
        var aMeta = a.GetComponent<ItemMeta>();
        var bMeta = b.GetComponent<ItemMeta>();
        return a != null && b != null && aMeta.id.Equals(bMeta.id);
    }
}
