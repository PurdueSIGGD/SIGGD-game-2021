using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject player;
    public bool test = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GlobalControl.Instance.checkpoint;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
