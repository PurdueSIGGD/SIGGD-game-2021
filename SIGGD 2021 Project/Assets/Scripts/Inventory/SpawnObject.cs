using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnObject()
    {
        GameObject newObj = GameObject.Instantiate(gameObject, location.position, Quaternion.identity);
        newObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
