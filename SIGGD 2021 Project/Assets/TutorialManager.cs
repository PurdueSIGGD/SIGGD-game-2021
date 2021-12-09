using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private GameObject player;
    public Vector2 checkPoint;
    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        checkPoint = player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(test)
        {
            playerCaught();
            test = !test;
        }
    }

    public void playerCaught()
    {
        player.transform.position = checkPoint;
    }

}
