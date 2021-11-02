using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    // Allows an item to have a default and alternative sprites, which lets items affect their graphics
    public Sprite defaultSprite;

    public Sprite GetSprite()
    {
        // Check to see if any components change the sprite (first change found is applied), otherwise return default
        Sprite changedSprite = GetComponentInChildren<IChangeItemSprite>()?.GetSprite();
        return (changedSprite) ? changedSprite : defaultSprite;
    }
}

public interface IChangeItemSprite
{
    // Return null if the sprite should be the same
    public Sprite GetSprite();
}
