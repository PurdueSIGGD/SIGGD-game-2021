using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisbilityCloak : MonoBehaviour
{
    [SerializeField]
    private string invisibleLayerName = "Invisible";

    [SerializeField]
    private string playerLayerName = "Player";

    [SerializeField]
    List<SpriteRenderer> visibilityList;

    GameObject playerObject;

    private void Start()
    {
        playerObject = transform.parent.parent.gameObject;
        visibilityList.AddRange(playerObject.GetComponentsInChildren<SpriteRenderer>());
    }

    public void StartInvisibility()
    {
        playerObject.layer = LayerMask.NameToLayer(invisibleLayerName);
        List<SpriteRenderer> removeList = new List<SpriteRenderer>();
        foreach (SpriteRenderer sr in visibilityList) {
            if (!sr) { 
                removeList.Add(sr); 
            } else
            {
                sr.enabled = false;
            }
        }
        foreach (SpriteRenderer sr in removeList)
        {
            visibilityList.Remove(sr);
        }
    }

    public void EndInvisibility()
    {
        playerObject.layer = LayerMask.NameToLayer(playerLayerName);
        List<SpriteRenderer> removeList = new List<SpriteRenderer>();
        foreach (SpriteRenderer sr in visibilityList)
        {
            if (!sr)
            {
                removeList.Add(sr);
            }
            else
            {
                sr.enabled = true;
            }
        }
        foreach (SpriteRenderer sr in removeList)
        {
            visibilityList.Remove(sr);
        }
    }
}
