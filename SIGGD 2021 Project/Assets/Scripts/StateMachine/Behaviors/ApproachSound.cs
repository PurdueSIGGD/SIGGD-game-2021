using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachSound : Behavior
{
    [SerializeField] private HearSound[] hearSound;
    [SerializeField] private NavmeshAgent navmeshAgent;
    [SerializeField] private DestinationReached destinationReached;

    private Vector2 soundOrigin;

    public override void run()
    {
        navmeshAgent.navigateTo(soundOrigin);
    }

    public override void OnBehaviorEnter()
    {
        soundOrigin = transform.position;
        foreach (HearSound sound in hearSound)
        {
            if (sound.position != null)
            {
                soundOrigin = sound.position.Value;
            }
        }
        destinationReached.setDestination(soundOrigin);
    }

    public override void OnBehaviorExit()
    {

    }
}
