using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public LayerMask interactLayers;
    public float range = .8f;

    // Interacting has a natural cooldown
    private Timer timer;
    private bool interactReady = true;

    [SerializeField] private UnityEvent<GameObject> onInteract;

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

            // Interact with the single nearest object marked as interactable (via the component)
            Collider2D[] objectsFound = Physics2D.OverlapCircleAll(transform.position, range, interactLayers);
            Interactable interactable = null;
            float minDistance = float.MaxValue;
            foreach (Collider2D obj in objectsFound) {
                float currDistance = (obj.transform.position - transform.parent.position).sqrMagnitude;
                if (currDistance < minDistance)
                {
                    interactable = obj.gameObject.GetComponent<Interactable>();
                    minDistance = currDistance;
                }

                //var interactable = obj.gameObject.GetComponent<Interactable>();
            }
            interactable?.interact();

            if (interactable != null)
            {
                onInteract.Invoke(interactable.gameObject);
            }
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
