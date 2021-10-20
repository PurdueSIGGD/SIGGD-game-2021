using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroupMember))]
public class SeeEnemyOutsideGroup : Trigger
{
    [HideInInspector]
    public GroupMember visibleEnemy; //the enemy that is seen outside of the group 

    private GroupMember thisGroupMember;

    private void Start()
    {
        thisGroupMember = GetComponent<GroupMember>();
    }
    /**
     * If you see an enemy with a groupMember component indicating that they can be part of a group and that enemy is not in the same group that you are in then return true. If both you and your enemy do not have a group then the enemy 
     * be treated as though they are not in the same group as you even though the value of your respective group variables are the same. 
     */
    public override bool isActive()
    {
        //get array of all enemies in the scene
        //raycast to each enemy to see if they are visible
        //if they are visible check that they are not in the same group as you
        //if they are visible and they are not in the same group as you or you both don't have a group then return false 

        GroupMember[] groupableEnemiesInScene = FindObjectsOfType<GroupMember>();
        foreach (GroupMember groupableEnemy in groupableEnemiesInScene)
        {
            if (groupableEnemy == thisGroupMember) { continue; }
            Vector3 groupableEnemyPos = groupableEnemy.gameObject.transform.position;
            LayerMask enemyMask = (int)(Mathf.Pow(2, 7));
            LayerMask layerMask = ~enemyMask; //ignore collisions with enemies 
            RaycastHit2D hit = Physics2D.Linecast(transform.position, groupableEnemyPos, layerMask);
            if (!hit) //if you can draw a line from this enemy to the other enemy without hitting anything 
            {
                if (groupableEnemy.groupLeader != thisGroupMember.groupLeader || groupableEnemy.groupLeader == null && thisGroupMember.groupLeader == null)
                {
                    //if you are not in the same group or both you and your enemy don't have a group then you are not in the same group as your enemy
                    visibleEnemy = groupableEnemy;
                    return true;
                }
            }

        }
        return false;
    }

    /**
     * if the visible enemy already is in a group then you will join the group that the visible enemy is in. if the visible enemy doesn't have a group then they will be ignored because it's probably not a good idea to tell other enemies
     * what to do just because they have a group component. 
     */
    public void makeGroupWithVisibleEnemy()
    {

        if (visibleEnemy.groupLeader != null)
        {
            thisGroupMember.groupLeader = visibleEnemy.groupLeader;
            thisGroupMember.groupMembers = visibleEnemy.groupMembers;
            thisGroupMember.groupMembers.Add(thisGroupMember);
        }
    }
}
