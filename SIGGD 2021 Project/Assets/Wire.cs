using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private bool isPowered = false;

    private List<Wire> Wires = new List<Wire>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Wires.Count != 0)
        {
            bool hasPower = false;
            foreach(Wire wire in Wires)
            {
                if (wire.IsPowered())
                {
                    hasPower = true;
                }
            }
            isPowered = hasPower;
        }
        else
        {
            isPowered = false;
        }

        if (Wires.Count != 0 && isPowered)
        {
            foreach (Wire wire in Wires)
            {
                wire.SetPower(true);
            }
        }
        else
        {
            foreach (Wire wire in Wires)
            {
                wire.SetPower(false);
            }
        }

        
    }

    public bool IsPowered()
    {
        return isPowered;
    }

    public void SetPower(bool value)
    {
        isPowered = value;
    }
}
