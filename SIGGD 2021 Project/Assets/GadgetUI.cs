using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GadgetUI : MonoBehaviour
{
    [SerializeField] private Image gadget;
    [SerializeField] private Sprite sprite;

    public void updateImage(Sprite source)
    {
        gadget.sprite = source;
    }

    // Start is called before the first frame update
    void Start()
    {
        updateImage(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
