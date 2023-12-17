using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : EnemyBaseState
{
    public float steeringSpeed = 150;
    public float maxSpeed = 5;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered flee state");
    }
    
    public override void UpdateState(EnemyStateManager enemy)
    {

        if (!enemy.IsPlayerLookingAtEnemy(45))
        {
            enemy.SwitchState(enemy.ChaseState);
        }
        else 
        {
            Vector3 fleeDirection = enemy.transform.position - enemy.PlayerTransform.position;
            Vector3 normalizedFleeDirection = fleeDirection.normalized;
            enemy.Body.velocity += normalizedFleeDirection * steeringSpeed * Time.deltaTime;

            enemy.Body.velocity = Vector3.ClampMagnitude(enemy.Body.velocity, maxSpeed);
        }
    }
}
