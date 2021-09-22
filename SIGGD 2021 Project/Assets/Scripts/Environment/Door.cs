using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool open = false;

    // # of seconds to open the door
    public float openDelay = 0.5f;

    // # of seconds to close the door
    public float closeDelay = 0.5f;

    // Game Event to trigger when opened, closed, or both
    public GameEvent openEvent, closeEvent;


    SpriteRenderer sprite;
    



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Open();
        } else
        {
            Close();
        }
    }

    // Starts/finishes the opening process
    void Open()
    {
        open = true;
        openEvent.Invoke();
    }

    // Starts/finishes the closing process
    void Close()
    {
        open = false;
        closeEvent.Invoke();
    }

    // Toggles the door
    void Toggle()
    {
        if (open)
        {
            Close();
        } else
        {
            Open();
        }
    }
}
