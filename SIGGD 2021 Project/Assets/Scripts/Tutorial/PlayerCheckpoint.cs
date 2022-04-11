using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public Vector2 checkpoint; 

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = GlobalControl.Instance.checkpoint;
    }

    public void saveCheckpoint()
    {
        GlobalControl.Instance.checkpoint = checkpoint;
    }
}
