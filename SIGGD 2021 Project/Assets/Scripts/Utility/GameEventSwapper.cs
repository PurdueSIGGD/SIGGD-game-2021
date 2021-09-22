using UnityEngine;
using UnityEngine.Events;

// credit to Jason Weimann
public class GameEventSwapper : GameEventListener {
	[SerializeField] private UnityEvent unityEvent2;

	private bool first = true;

	public override void RaiseEvent() {
		if (first)
		{
			unityEvent.Invoke();
		} else
        {
			unityEvent2.Invoke();
		}
		first = !first;
	}
}
