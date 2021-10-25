using UnityEngine;

public class interactable : MonoBehaviour
{
    [SerializeField]
    private GameEvent eventToCall;

    public void interact()
    {
        eventToCall.Invoke();
    }
}
