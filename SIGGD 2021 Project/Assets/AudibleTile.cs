using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudibleTile : MonoBehaviour
{
    public bool isTriggered = false;
    public Material triggeredMaterial;
    public AudioSource triggerSound;
    private CircleCollider2D soundCollider;
    public int radius = 3;

    private void Start()
    {
        soundCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<isGrounded>().grounded && !isTriggered)
        {
            isTriggered = true;
            gameObject.GetComponent<SpriteRenderer>().material = triggeredMaterial;
            timer();
        }
    }

    IEnumerator timer()
    {
        soundCollider.radius = radius;
        yield return new WaitForSecondsRealtime(.3f);
        soundCollider.radius = 0;
    }
}
