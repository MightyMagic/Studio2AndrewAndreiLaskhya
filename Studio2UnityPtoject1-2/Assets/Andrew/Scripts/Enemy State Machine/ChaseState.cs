using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : EnemyBaseState
{
    public float steeringSpeed = 150;
    public float maxSpeed = 5;
    Vector3 playerToEnemy;
    Vector3 PlayerForward;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered chase state");

        steeringSpeed = enemy.steeringSpeed;
        maxSpeed = enemy.maxSpeed;

        playerToEnemy = enemy.PlayerTransform.position - enemy.transform.position;
        PlayerForward = enemy.playerForward.forward;

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        float DistanceBetweenPlayer = Vector3.Distance(enemy.PlayerTransform.position, enemy.transform.position);

        if (DistanceBetweenPlayer >= enemy.DistanceToChase)
        {
            enemy.SwitchState(enemy.PatrolState);
        }

        float dotProduct = Vector3.Dot(PlayerForward, playerToEnemy);

        if (dotProduct >= 0)
        {
            enemy.SwitchState(enemy.FleeState);
        }
        else
        {
            Vector3 direction = enemy.PlayerTransform.position - enemy.transform.position;
            Vector3 normalizedDirection = direction.normalized;
            enemy.Body.velocity += normalizedDirection * steeringSpeed * Time.deltaTime;

            //if (rb.velocity.magnitude >= maxSpeed)
            //{
            //Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            //}

            Vector3.ClampMagnitude(enemy.Body.velocity, maxSpeed);
        }

        //Vector3.Dot
    }
}
