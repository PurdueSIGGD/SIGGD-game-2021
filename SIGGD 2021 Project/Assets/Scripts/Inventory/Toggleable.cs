using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour, ICanUse
{
    public bool toggled;

    public void Toggle()
    {
        toggled = !toggled;
    }

    public bool canUse()
    {
        return toggled;
    }
}