using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.U2D;

public class CameraScript : MonoBehaviour
{
    private GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = GetComponent<PixelPerfectCamera>().RoundToPixel(player.transform.position);
        gameObject.transform.position += Vector3.back;
    }
}
