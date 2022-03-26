using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circling : Behavior
{
    //Circles the player for a set amount of time

    [SerializeField] private ApproachPlayer approachPlayer;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private DestinationReached dest;
    [SerializeField] private NavmeshAgent nav;
    [SerializeField] private Timer timer;
    [SerializeField] private ConeRaycaster cone;
    [SerializeField] private float speed;

    //Vector array contain offsets to the player
    private Vector2[] vectorArr = {new Vector2(1.4f, 1.4f), new Vector2(-1.4f, 1.4f),
        new Vector2(-1.4f, -1.4f), new Vector2(1.4f, -1.4f)};
    private int index = 0;

    private bool timerStart = false;
    
    public override void run()
    {
        Debug.Log(approachPlayer.dest);
        Vector2 playerV = approachPlayer.dest.position;
        Vector2 enemyV = enemyTransform.position;

        nav.navigateTo(playerV + vectorArr[index]); //navigates to location

        //code to set cone look angle
        float angle = Vector2.SignedAngle(Vector2.right, new Vector2(playerV.x - enemyV.x, playerV.y - enemyV.y));
        cone.setCenterAngle(angle);

        if (dest.isActive())
        {
            if (!timerStart)
            {
                //start timer if we just got close to the player
                timer.StartTimer();
                timerStart = true;
            }

            //update index to go to new location near player
            index++;
            if (index == 4)
            {
                index = 0;
            }
        }
    }

    public override void OnBehaviorEnter()
    {
        nav.setAgentSpeed(speed);
    }

    public override void OnBehaviorExit()
    {

    }
}
