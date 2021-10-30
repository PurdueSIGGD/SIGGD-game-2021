using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityFaction
{
    Player, Soldier, Savage
}

public class FactionComponent : MonoBehaviour
{
    // [SerializeField] private EntityFaction _tag;

    [field: SerializeField] 
    public EntityFaction faction {get; private set;}
}
