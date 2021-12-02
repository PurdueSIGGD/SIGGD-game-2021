using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : Power
{
    [SerializeField] private List<Power> outComponents;
    private bool isDisabled = false;

    public override void propagate(bool value) { }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Power component in outComponents)
        {
            component.propagate(true);
        }
    }
}
