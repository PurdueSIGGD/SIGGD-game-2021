using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Mappings/String To Prefab")]
public class StringToPrefabScriptable : ScriptableObject {

    [System.Serializable]
    public struct Pair { public string id; public GameObject prefab; }

    [SerializeField] private List<Pair> mapping;

    public GameObject getPrefab(string id) {
        return mapping.Find((p) => p.id.Equals(id)).prefab;
    }
}