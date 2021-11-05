using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSignal : MonoBehaviour
{
    [SerializeField] private Transform signalTransform;
    private void OnTriggerStay2D(Collider2D other) {
        other.GetComponent<ISoundSignalListener>()?.Signal(signalTransform.position);
    }
}

public interface ISoundSignalListener {
    void Signal(Vector3 point);
}