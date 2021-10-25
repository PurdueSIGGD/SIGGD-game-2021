using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMember : MonoBehaviour
{
    public GroupMember groupLeader;
    [HideInInspector]
    public List<GroupMember> groupMembers = new List<GroupMember>();
}
