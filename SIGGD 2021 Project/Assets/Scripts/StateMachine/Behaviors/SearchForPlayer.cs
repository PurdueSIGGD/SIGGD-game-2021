using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchForPlayer : Behavior
{
    public override void run()
    {
        //search for player. for now does nothing b/c idk what searching for the player is going to look like yet
    }

    public override void OnBehaviorEnter()
    {
        Debug.Log("Searching");
    }

    public override void OnBehaviorExit()
    {
        
    }
}
