using UnityEngine;

public class areaDetector : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToCall;

    [SerializeField]
    private bool onEnter = true;

    [SerializeField]
    private bool onStay = true;

    [SerializeField]
    private bool onExit = true;

    [SerializeField]
    private LayerMask layers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onEnter && (layers.value & (1 << collision.gameObject.layer)) > 0)
        {
            eventToCall.Invoke();
            //Debug.Log("Detected in area");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onStay && (layers.value & (1 << collision.gameObject.layer)) > 0)
        {
            eventToCall.Invoke();
            Debug.Log("Detected in area");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onExit && (layers.value & (1 << collision.gameObject.layer)) > 0)
        {
            eventToCall.Invoke();
            Debug.Log("Detected in area");
        }
    }
}
