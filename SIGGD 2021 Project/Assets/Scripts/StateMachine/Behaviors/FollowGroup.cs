using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavmeshAgent))]
[RequireComponent(typeof(GroupMember))]
public class FollowGroup : Behavior
{
    private NavmeshAgent navmeshAgent;
    private GroupMember groupMember;

    public float followDistance = 1.5f; //how far away the enemy will stay when following the group leader

    private void Start()
    {
        navmeshAgent = GetComponent<NavmeshAgent>();
        groupMember = GetComponent<GroupMember>();
    }

    public override void run()
    {
        GroupMember groupLeader = groupMember.groupLeader;
        if (groupLeader == null)
        {
            Debug.Log("Cannot follow group that doesn't have a group leader!");
            return;
        }
        Vector3 groupLeaderPos = groupLeader.transform.position;
        if (Vector3.Distance(groupLeaderPos, transform.position) > followDistance)
        {
            navmeshAgent.navigateTo(groupLeaderPos);
        }
    }

    public override void OnBehaviorEnter()
    {
        base.OnBehaviorEnter();
    }

    public override void OnBehaviorExit()
    {
        base.OnBehaviorExit();
    }
}
