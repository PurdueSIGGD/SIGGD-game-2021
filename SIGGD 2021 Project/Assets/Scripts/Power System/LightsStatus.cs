using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsStatus : MonoBehaviour
{
    private bool status;
    [SerializeField] private BoxCollider2D collider;
    private List<collider2D> entityList = new List<collider2D>();
    private ContactFilter2D contactFilter;

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
        if (!status)
        {
            collider.OverlapCollider(, entityList);
        }
    }
}
