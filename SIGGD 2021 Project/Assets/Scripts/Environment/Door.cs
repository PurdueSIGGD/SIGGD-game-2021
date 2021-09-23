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

    // Game Event to trigger when opened, closed
    public GameEvent openEvent, closeEvent;
    SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Starts/finishes the opening process. Called by events.
    public void Open()
    {
        open = true;
        openEvent?.Invoke();
    }

    // Starts/finishes the closing process. Called by events.
    public void Close()
    {
        open = false;
        closeEvent?.Invoke();
    }

    // Toggles the door. Called by events.
    public void Toggle()
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
