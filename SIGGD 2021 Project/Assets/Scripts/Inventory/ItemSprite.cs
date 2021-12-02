using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    // Allows an item to have a default and alternative sprites, which lets items affect their graphics
    public Sprite defaultInvSprite;
    public Sprite defaultWorldSprite;

    // Sets the item size, usually based on the size of the sprite
    public Vector2 spriteSize;

    public Sprite GetInvSprite()
    {
        // Check to see if any components change the sprite (first change found is applied), otherwise return default
        Sprite changedSprite = GetComponentInChildren<IChangeInvSprite>()?.GetInvSprite();
        return (changedSprite) ? changedSprite : defaultInvSprite;
    }

    public Sprite GetWorldSprite()
    {
        // Check to see if any components change the sprite (first change found is applied), otherwise return default
        Sprite changedSprite = GetComponentInChildren<IChangeWorldSprite>()?.GetWorldSprite();
        return (changedSprite) ? changedSprite : defaultWorldSprite;
    }
}

// Interface to change the inventory sprite
public interface IChangeInvSprite
{
    // Return null if the sprite should be the same
    public Sprite GetInvSprite();
}

// Interface to change the world (dropped) sprite
public interface IChangeWorldSprite
{
    // Return null if the sprite should be the same
    public Sprite GetWorldSprite();
}
