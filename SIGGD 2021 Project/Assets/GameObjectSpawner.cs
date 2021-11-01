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
}
