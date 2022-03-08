using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Behavior
{
    System.Random rand = new System.Random();
    [SerializeField] private Transform enemyT;
    [SerializeField] private NavmeshAgent nav;
    [SerializeField] private int height;
    [SerializeField] private int width;
    private Vector2 enemyLoc;
    private bool firstRun = true;
    private float timer;

    public override void run()
    {
        if (firstRun)
        {
            firstRun = false;
            enemyLoc = enemyT.position;
        }

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            Vector2 randLoc = new Vector2(rand.Next(-width, width), rand.Next(-height, height));
            nav.navigateTo(enemyLoc + randLoc);
        }
        
    }
    
    public override void OnBehaviorEnter()
    {
    }

    public override void OnBehaviorExit()
    {

    }
}
