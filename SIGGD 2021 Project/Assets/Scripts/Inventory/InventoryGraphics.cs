using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGraphics : MonoBehaviour
{
    // Sprites for when the inventory item is currently able to be used or not.
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;

    // UI element references for displayed parts
    [SerializeField] private Image borderImage;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text stackText;

    private Inventory inv;

    private void Start()
    {
        inv = GetComponent<Inventory>();
    }

    // Used for when the displayed item needs to be updated
    public void UpdateDisplayedItem()
    {
        if (!inv.equippedItem)
        {
            // Remove any icon
            return;
        }

        // Recalculate the item sprite
        ICanUse item = inv.equippedItem.GetComponent<ICanUse>();
        
        
    }
}
