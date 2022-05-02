using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VisionTutorialManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorialTextObject;
    public GameObject checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GlobalControl.Instance.checkpoint;
        tutorialTextObject = GameObject.Find("Tutorial Text");
    }

    public void playerCaught()  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateNavmash() {
		//navmeshScript.center = GlobalControl.Instance.checkpoint;
        //navmeshScript.generateNavmesh();
		// move center of navmash to position of checkpoint
		// re-generate navmesh
	}
}
