using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudibleTile : MonoBehaviour
{
    public bool isTriggered = false;
    // public AudioSource triggerSound;
    [SerializeField] private CircleCollider2D soundCollider;
    public float radius = 3.0f;
    [SerializeField] private Timer soundTriggerPlayTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTriggered && other.gameObject.layer == 3 && other.GetComponent<isGrounded>()?.grounded == true)
        {
            soundTriggerPlayTimer.StartTimer();
            soundCollider.enabled = true;
            soundCollider.radius = this.radius;
            isTriggered = true;
        }
    }
}
