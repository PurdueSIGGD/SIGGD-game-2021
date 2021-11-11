using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public GameObject invItem {
        set { 
            invItem = value;
            GetComponent<SpriteRenderer>().sprite = value.GetComponent<ItemSprite>().GetWorldSprite();
        }
    }
}
