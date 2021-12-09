using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float destroyDelay;
    [SerializeField] private GameObject thisObject;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(thisObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
