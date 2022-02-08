using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSignal : MonoBehaviour
{
    [SerializeField] private Transform signalTransform;
    [SerializeField] private int soundType = 0; //0 = from player (movement/actions), 1 = from enemy (call for help/alerts), 2 = other
    private void OnTriggerStay2D(Collider2D other) {
        other.GetComponent<ISoundSignalListener>()?.Signal(signalTransform.position, soundType);
    }
}

public interface ISoundSignalListener {
    void Signal(Vector3 point, int origin); //0 = from player (movement/actions), 1 = from enemy (call for help/alerts), 2 = other
}