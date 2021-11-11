using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    public void Spawn()
    {
        Instantiate(prefab);
    }

    public void Update() {
        if(Input.GetKey(KeyCode.J)) {
            Spawn();
        }
    }
}
