using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGraphics : MonoBehaviour
{
    GameObject currentInstance;

    // Used for when the displayed item needs to be changed
    public void SetDisplayedItem(string id)
    {
        if (currentInstance) {
            ClearDisplayedItem();
        }

        if (id != null)
        {
            ItemPrefabs newItem = ItemMeta.mappings.get(id);
            if (newItem != null)
            {
                var uiInstance = Instantiate(newItem.ui, transform);

                currentInstance = uiInstance;
            }
        }
    }

    // Resets the inventory icon 
    private void ClearDisplayedItem()
    {
        Destroy(currentInstance);
        currentInstance = null;
    }
}
