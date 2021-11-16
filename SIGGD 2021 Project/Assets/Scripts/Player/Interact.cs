using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public LayerMask interactLayers;
    public float range = .8f;

    // Interacting has a natural cooldown
    private Timer timer;
    private bool interactReady = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E) && interactReady)
        {
            interactReady = false;
            timer.StartTimer();

            Debug.DrawLine(transform.position, transform.position + new Vector3(range, 0, 0));

            // Interact with everything marked as interactable (via the component)
            Collider2D[] objectsFound = Physics2D.OverlapCircleAll(transform.position, range, interactLayers);
            foreach (Collider2D obj in objectsFound) {
                Debug.Log("Interacting with " + obj.gameObject.name);
                obj.gameObject.GetComponent<Interactable>()?.interact();
            }

            Debug.Log(objectsFound);
        }
    }

    public void RefreshInteraction()
    {
        interactReady = true;
    }

    void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
