using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VisionTutorialManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorialTextObject;
    public GameObject checkpoints;
	public GameObject navmesh; 
	public Navmesh navmeshScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		navmeshScript = navmesh.GetComponent<Navmesh>();
        navmeshScript.center = new Vector2(GlobalControl.Instance.checkpoint.x, GlobalControl.Instance.checkpoint.y);
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
		navmeshScript.center = GlobalControl.Instance.checkpoint;
        navmeshScript.generateNavmesh();
		// move center of navmash to position of checkpoint
		// re-generate navmesh
	}
}
