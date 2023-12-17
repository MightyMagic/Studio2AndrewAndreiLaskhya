using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : EnemyBaseState
{
    public float steeringSpeed = 150;
    public float maxSpeed = 5;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Entered chase state");

        steeringSpeed = enemy.steeringSpeed;
        maxSpeed = enemy.maxSpeed;


    }
    public override void UpdateState(EnemyStateManager enemy)
    {

        if (enemy.IsPlayerLookingAtEnemy(45))
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

            enemy.Body.velocity = Vector3.ClampMagnitude(enemy.Body.velocity, maxSpeed);
        }

        //Vector3.Dot
    }
}
