using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered patrol state");
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.Body.velocity = Vector3.zero;

        float DistanceBetweenPlayer = Vector3.Distance(enemy.PlayerTransform.position, enemy.transform.position);

        if (DistanceBetweenPlayer <= enemy.DistanceToChase)
        {
            enemy.SwitchState(enemy.ChaseState);
        }
        
    }
}
