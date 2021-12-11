using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptable Mappings/String To Item Prefabs")]
public class IDToItemPrefabs: TypeAToBScriptable<string, ItemPrefabs> {

}

[System.Serializable]
public class ItemPrefabs {
    public GameObject pickup;
    public GameObject system;
    public GameObject ui;
}