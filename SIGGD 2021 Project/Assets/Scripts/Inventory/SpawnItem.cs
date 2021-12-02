using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private GameObject worldItem;

    [SerializeField]
    private GameObject itemToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newWorldItem = Instantiate(worldItem, transform.position, Quaternion.identity, transform.parent);
        GameObject newInventoryItem = Instantiate(itemToSpawn, transform.position, Quaternion.identity, newWorldItem.transform);
        Destroy(gameObject);
    }
}
