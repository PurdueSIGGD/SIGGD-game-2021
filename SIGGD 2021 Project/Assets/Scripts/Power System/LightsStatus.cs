using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsStatus : MonoBehaviour
{
    private bool status;
    [SerializeField] private BoxCollider2D collider;

    public void setStatus(bool value)
    {
        status = value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collider.enabled = !status;
    }
}
