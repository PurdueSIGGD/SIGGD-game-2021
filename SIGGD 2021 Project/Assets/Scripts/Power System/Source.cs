using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Source : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> propagateEvent;
    [SerializeField] private List<Power> outComponents;

    // NOTE: Having +2 previous components linked to a component is not yet
    // supported

    private bool isDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDisabled = !isDisabled;
        }
        foreach (Power component in outComponents)
        {
            component.propagate(!isDisabled);
        }

        propagateEvent.Invoke(!isDisabled);
    }
}
