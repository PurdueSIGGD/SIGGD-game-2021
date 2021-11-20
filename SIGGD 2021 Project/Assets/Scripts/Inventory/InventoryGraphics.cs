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

    // Initialize
    private void Start()
    {
        inv = GetComponent<Inventory>();
        UpdateDisplayedItem();
    }

    // Used for when the displayed item needs to be updated
    public void UpdateDisplayedItem()
    {
        ResetInventoryIcon();

        if (!inv.equippedItem)
        {
            // If there is no item, disable the icon
            return;
        }

        // Make the border light up if the item can be used
        if (inv.equippedItem.GetComponent<ItemControl>().CanUse())
        {
            borderImage.sprite = enabledSprite;
        }

        itemImage.sprite = inv.equippedItem.GetComponent<ItemSprite>().GetInvSprite();
        if (itemImage.sprite)
        {
            itemImage.enabled = true;
        }

        // Integrate some of the item controls into the graphics
        foreach (var control in inv.equippedItem.GetComponentsInChildren<ICanUse>())
        {
            UpdateItemControl(control);
        }
    }

    // Updates based on a single ICanUse (called for each property)
    private void UpdateItemControl(ICanUse control)
    {
        if (control is Stackable)
        {
            stackText.text = ((Stackable)control).count.ToString();
            stackText.enabled = true;
        }
    }

    // Resets the inventory icon 
    private void ResetInventoryIcon()
    {
        borderImage.sprite = disabledSprite;
        itemImage.enabled = false;
        stackText.enabled = false;
    }
}
