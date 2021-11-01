using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Not intended to be used as an actual player controller. Just for testing purposes
 */
public class SimplePlayerController : MonoBehaviour
{
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.Translate(moveDir * Time.deltaTime * speed);
    }
}
