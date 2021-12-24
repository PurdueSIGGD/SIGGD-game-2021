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

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = GameObject.Find("Checkpoints");
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
            tutorialTextObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "Also, Press Ctrl to Sneak";
        }
    }

}
