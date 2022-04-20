using UnityEngine;

public class NearAlerted : Trigger
{
    [SerializeField] private float detectionRaidus = 16;
    private AIStateManager[] enemies;
    [SerializeField] private ApproachFriendly approachTarget;
    private EntityFaction thisFaction;

    private void Start()
    {
        enemies = FindObjectsOfType<AIStateManager>();
        thisFaction = transform.parent.parent.GetComponent<FactionComponent>().faction;
    }

    public override bool isActive()
    {
        foreach (AIStateManager enemy in enemies)
        {
            if (enemy != null && enemy.GetComponent<FactionComponent>().faction.Equals(thisFaction))
            {
                if (Mathf.Pow(transform.position.x - enemy.transform.position.x, 2) + Mathf.Pow(transform.position.y - enemy.transform.position.y, 2) < detectionRaidus*detectionRaidus) {
                    Behavior enemyBehavior = enemy.activeState.behavior;
                    if (enemyBehavior is ApproachPlayer || enemyBehavior is ApproachSound || enemyBehavior is SearchForPlayer)
                    {
                        approachTarget.friendly = enemy.transform;
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
