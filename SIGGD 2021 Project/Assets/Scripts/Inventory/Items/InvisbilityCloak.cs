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
        foreach (SpriteRenderer sr in visibilityList) {
            sr.enabled = false;
        }
    }

    public void EndInvisibility()
    {
        playerObject.layer = LayerMask.NameToLayer(playerLayerName);
        foreach (SpriteRenderer sr in visibilityList)
        {
            sr.enabled = true;
        }
    }
}
