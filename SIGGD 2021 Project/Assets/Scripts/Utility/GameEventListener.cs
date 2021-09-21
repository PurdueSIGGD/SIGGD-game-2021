using UnityEngine;
using UnityEngine.Events;

// credit to Jason Weimann
public class GameEventListener : MonoBehaviour {
	[SerializeField] private GameEvent gameEvent;
	[SerializeField] protected UnityEvent unityEvent;

	public virtual void RaiseEvent() => unityEvent.Invoke();
	private void Awake() => gameEvent.Register(this);
	private void OnDestroy() => gameEvent.Deregister(this);
}