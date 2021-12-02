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

    void OnDrawGizmosSelected()
    {
        // Visualize the hitbox of spriteSize for easier editing

        if (Application.isPlaying) return;
        if (spriteSize.x < 0.05 || spriteSize.y < 0.05) return;
        Vector3 tr = (spriteSize * 0.5f) / 32f;
        Vector3 tl = new Vector3(-tr.x, tr.y, tr.z);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + tr, transform.position - tl);
        Gizmos.DrawLine(transform.position - tr, transform.position - tl);
        Gizmos.DrawLine(transform.position - tr, transform.position + tl);
        Gizmos.DrawLine(transform.position + tr, transform.position + tl);
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
