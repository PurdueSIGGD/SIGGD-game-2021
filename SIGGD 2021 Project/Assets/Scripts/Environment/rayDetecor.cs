using UnityEngine;

public class rayDetecor : MonoBehaviour
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
    private float start = 1;

    [SerializeField]
    private float length = 2;

    [SerializeField]
    private LayerMask layers;

    private bool staying = false;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.right * start, transform.right, length, layers);
        if (hit && hit.transform != transform)
        {
            if (staying)
            {
                if (onStay)
                {
                    eventToCall.Invoke();
                }
            } else
            {
                if (onEnter)
                {
                    eventToCall.Invoke();
                }
                staying = true;
            }
        }
        else
        {
            if (staying)
            {
                if (onExit)
                {
                    eventToCall.Invoke();
                }
                staying = false;
            }
        }
    }
}
