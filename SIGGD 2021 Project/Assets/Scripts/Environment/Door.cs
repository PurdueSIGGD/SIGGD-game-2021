using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool startOpen = false;
    private bool open = false;

    // Optional Game Event to trigger when opened, closed (if you want the door to trigger something else)
    public GameEvent openEvent, closeEvent;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        // Open or close the door so its state
        if (startOpen != open)
        {
            if (open)
            {
                CloseInternal();
            } else
            {
                OpenInternal();
            }
        }
    }

    // Starts/finishes the opening process. Called by events.
    public void Open()
    {
        openEvent?.Invoke();

        OpenInternal();
    }

    // Starts/finishes the closing process. Called by events.
    public void Close()
    {
        closeEvent?.Invoke();

        CloseInternal();
    }

    // Opens the door without triggering events. Used for resetting.
    private void OpenInternal()
    {
        open = true;

        // Just disable the sprite right now
        sprite.enabled = false;
    }

    // Closes the door without triggering events. Used for resetting.
    private void CloseInternal()
    {
        open = false;

        // Just re-enable the sprite right now
        sprite.enabled = true;
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
