using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayIntToText : MonoBehaviour
{
    [SerializeField] private TMP_Text counter;

    public void updateCounter(int a)
    {
        counter.text = a.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        updateCounter(9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
