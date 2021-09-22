using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : EnemyBehavior
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void doBehavior()
    {
        //called in EnemyMovement each frame while this state is active
    }

    public override void OnStateEnter()
    {
        //called once when this state gets switched to from another state
    }

    public override void OnStateExit()
    {
        //called once when this state gets exited from to another state
    }
}
