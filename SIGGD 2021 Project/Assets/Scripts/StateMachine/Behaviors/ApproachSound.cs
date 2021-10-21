using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachSound : Behavior
{
    public Transform soundTransform;
    [SerializeField] private Transform enemyTransform;

    public float approachSpeed = 1f;
    private Transform soundOrigin;
    Vector3 dirToSound = new Vector3(0, 0, 0);

    public override void run()
    {
        dirToSound = (soundOrigin.position - enemyTransform.position).normalized;
        enemyTransform.Translate(dirToSound * Time.deltaTime * approachSpeed);
    }

    public override void OnBehaviorEnter()
    {
        soundOrigin = soundTransform;
    }

    public override void OnBehaviorExit()
    {

    }

    public bool destinationReached()
    {
        if (dirToSound.Equals(new Vector3(0, 0, 0)))
        {
            return true;
        }

        return false;
    }
}
