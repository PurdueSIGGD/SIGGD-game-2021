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
    private Scene currScene;
    public GameObject doors; 
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		//navmeshScript = navmesh.GetComponent<Navmesh>();
  //      navmeshScript.center = new Vector2(GlobalControl.Instance.checkpoint.x, GlobalControl.Instance.checkpoint.y);
        player.transform.position = GlobalControl.Instance.checkpoint;
        tutorialTextObject = GameObject.Find("Tutorial Text");
        updateText();
        currScene = SceneManager.GetActiveScene();
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
        if (currScene.name == "Sound_Tutorial")
        {
            if (GlobalControl.Instance.checkpoint == new Vector2(checkpoints.transform.GetChild(0).gameObject.transform.position.x, 0))
            {
                tutorialTextObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "And Ctrl to Sneak";
            }
        }
    }

    public void updateNavmash() {
		//navmeshScript.center = GlobalControl.Instance.checkpoint;
		//navmeshScript.navmeshNodes = navmeshScript.generateNavmesh();
		// move center of navmash to position of checkpoint
		// re-generate navmesh
	}
}
