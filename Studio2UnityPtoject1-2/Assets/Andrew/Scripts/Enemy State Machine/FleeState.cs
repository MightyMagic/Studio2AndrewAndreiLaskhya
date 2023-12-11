using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : EnemyBaseState
{
    public float steeringSpeed = 150;
    public float maxSpeed = 5;
    Vector3 playerToEnemy;
    Vector3 PlayerForward;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered flee state");

        playerToEnemy = enemy.PlayerTransform.position - enemy.transform.position;
        PlayerForward = enemy.playerForward.forward;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        float dotProduct = Vector3.Dot(PlayerForward, playerToEnemy);

        if (dotProduct <= 0)
        {
            enemy.SwitchState(enemy.FleeState);
        }
        else
        {
            Vector3 fleeDirection = enemy.transform.position - enemy.PlayerTransform.position;
            Vector3 normalizedDirection = fleeDirection.normalized;
            enemy.Body.velocity += normalizedDirection * steeringSpeed * Time.deltaTime;

            //if (rb.velocity.magnitude >= maxSpeed)
            //{
            //Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            //}

            Vector3.ClampMagnitude(enemy.Body.velocity, maxSpeed);
        }

        
    }
}
