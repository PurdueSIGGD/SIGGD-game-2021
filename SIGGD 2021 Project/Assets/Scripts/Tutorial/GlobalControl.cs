using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public Vector2 checkpoint;
    // Might be better to make a serialiazables script that holds the players information instead of having all the variables here
    // public PlayerStatistics savedPlayerData = new PlayerStatistics();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

   
}
