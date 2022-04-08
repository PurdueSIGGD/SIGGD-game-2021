using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorialTextObject;
    public GameObject checkpoints;
	public GameObject navmesh; 
	public Navmesh navmeshScript;
    public GameObject doors; 
    
    // Start is called before the first frame update
    void Start()
    {
		navmesh = GameObject.Find("Navmesh");
		navmeshScript = navmesh.GetComponent<Navmesh>();
        checkpoints = GameObject.Find("Checkpoints");
        navmeshScript.center = new Vector2(GlobalControl.Instance.checkpoint.x, GlobalControl.Instance.checkpoint.y);
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GlobalControl.Instance.checkpoint;
        tutorialTextObject = GameObject.Find("Tutorial Text");
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void playerCaught()  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void updateText()
    {
        if(GlobalControl.Instance.checkpoint == new Vector2(checkpoints.transform.GetChild(0).gameObject.transform.position.x, 0))
        {
            tutorialTextObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "And Ctrl to Sneak";
        }

        //if (doors.transform.GetChild(0).GetComponent <
    }

    public void updateNavmash() {
		navmeshScript.center = GlobalControl.Instance.checkpoint;
		navmeshScript.navmeshNodes = navmeshScript.generateNavmesh();
		// move center of navmash to position of checkpoint
		// re-generate navmesh
	}
}
