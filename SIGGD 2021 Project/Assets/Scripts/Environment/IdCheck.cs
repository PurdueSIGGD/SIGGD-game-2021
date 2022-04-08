using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdCheck : MonoBehaviour
{
    [SerializeField]
    private UnityEvent successEvent;
    [SerializeField]
    private UnityEvent failureEvent;

    [SerializeField]
    private string itemIDToAllow;

    private bool alwaysSuccess;


    // Checks the passed in ID. Calls successEvent on a match, and failureEvent on a non-match.
    public void CheckId(string str)
    {
        if (alwaysSuccess || itemIDToAllow.Equals(str))
        {
            successEvent.Invoke();
        } else
        {
            failureEvent.Invoke();
        }
    }

    // Enable/disable the string check. Disabling it will automatically call the success event.
    public void SetAlwaysSuccess(bool b)
    {
        alwaysSuccess = b;
    }
}
