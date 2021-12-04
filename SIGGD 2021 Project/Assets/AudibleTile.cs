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
        if (!isTriggered && other.GetComponent<isGrounded>()?.grounded == true && other.GetComponent<Rigidbody2D>() != null)
        {
            soundTriggerPlayTimer.StartTimer();
            soundCollider.radius = this.radius;
            isTriggered = true;
        }
    }

}
