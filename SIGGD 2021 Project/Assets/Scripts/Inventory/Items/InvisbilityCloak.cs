using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisbilityCloak : MonoBehaviour
{
    [SerializeField]
    private string invisibleLayerName = "Invisible";

    [SerializeField]
    private string playerLayerName = "Player";

    GameObject playerObject;

    private void Start()
    {
        playerObject = transform.parent.parent.gameObject;
    }

    public void StartInvisibility()
    {
        playerObject.layer = LayerMask.NameToLayer(invisibleLayerName);
        playerObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void EndInvisibility()
    {
        playerObject.layer = LayerMask.NameToLayer(playerLayerName);
        playerObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
