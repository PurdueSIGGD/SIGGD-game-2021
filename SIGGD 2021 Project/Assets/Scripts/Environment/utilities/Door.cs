using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool open = false;
    [SerializeField]
    private SpriteRenderer sprite;

    // Optional Game Event to trigger when opened, closed (if you want the door to trigger something else)
    [SerializeField]
    private GameEvent openEvent;
    [SerializeField]
    private GameEvent closeEvent;
    

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Public-facing open query
    public bool IsOpen()
    {
        return open;
    }

    // Starts/finishes the opening process. Called by events.
    public void Open()
    {
        openEvent?.Invoke();

        open = true;

        // Just disable the sprite right now
        sprite.enabled = false;
    }

    // Starts/finishes the closing process. Called by events.
    public void Close()
    {
        closeEvent?.Invoke();

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
