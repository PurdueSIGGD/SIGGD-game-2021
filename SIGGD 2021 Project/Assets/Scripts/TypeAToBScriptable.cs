using UnityEngine;
using System.Collections.Generic;

public class TypeAToBScriptable<A,B> : ScriptableObject {

    [System.Serializable]
    public struct Pair { public A id; public B value; }

    [SerializeField] private List<Pair> mapping;

    public B get(A id) {
        var value = mapping.Find((p) => p.id.Equals(id)).value;
        if (value == null) {
            Debug.LogError("id -  \"" + id + "\" could not be found!");
        }
        return value;
    }
}