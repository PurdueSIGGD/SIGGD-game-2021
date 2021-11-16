using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToCall;
    [SerializeField]
    private UnityEvent unityEventToCall;

    public void interact()
    {
        unityEventToCall.Invoke();
        eventToCall.Invoke();
    }
}
