using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    public abstract void run();

    public abstract void OnBehaviorEnter();

    public abstract void OnBehaviorExit();
}
