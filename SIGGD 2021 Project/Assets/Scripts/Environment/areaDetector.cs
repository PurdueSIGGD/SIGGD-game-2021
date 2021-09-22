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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onEnter)
        {
            eventToCall.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onStay)
        {
            eventToCall.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onExit)
        {
            eventToCall.Invoke();
        }
    }
}
