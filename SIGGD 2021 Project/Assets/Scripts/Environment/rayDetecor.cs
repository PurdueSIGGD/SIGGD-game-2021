using UnityEngine;

public class rayDetecor : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToCall;

    [SerializeField]
    private float length = 2;

    [SerializeField]
    private LayerMask layers;

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, transform.forward, length, layers))
        {
            eventToCall.Invoke();
        }
    }
}
