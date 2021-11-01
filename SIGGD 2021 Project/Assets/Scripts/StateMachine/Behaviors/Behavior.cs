using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    public virtual void run() {}

    public virtual void OnBehaviorEnter() {}

    public virtual void OnBehaviorExit() {}
}
