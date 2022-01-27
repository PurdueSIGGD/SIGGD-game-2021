using UnityEngine;
using UnityEngine.Events;

public abstract class GameEventListenerGeneric<T> : MonoBehaviour {
	// [SerializeField] private GameEventGeneric<T> gameEvent;
    protected abstract GameEventGeneric<T> gameEvent {get;}
	[SerializeField] protected UnityEvent<T> unityEvent;

	public virtual void RaiseEvent(T input) => unityEvent.Invoke(input);
	private void Awake() => gameEvent.Register(this);
	private void OnDestroy() => gameEvent.Deregister(this);
}