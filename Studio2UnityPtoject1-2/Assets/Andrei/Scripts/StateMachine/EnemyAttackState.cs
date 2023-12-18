using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState<EnemyStateMachine.EnemyState>
{
    [Header("Refs")]
    private float speed;
    private GameObject waypointsObject;
    private float damage;
    private TrailLogic trailLogic;


    [Header("Internal")]
    private Rigidbody rb;
    private GameObject player;

    private bool patrolling;
   

    public EnemyAttackState(float speed, GameObject waypointsObject, float damage, TrailLogic trailLogic, Rigidbody rb) : base(EnemyStateMachine.EnemyState.Attack)
    {
        this.speed = speed;
        this.waypointsObject = waypointsObject;
        this.damage = damage;
        this.trailLogic = trailLogic;
        this.rb = rb;
    }
    public override void EnterState()
    {
        Debug.Log("Entered attack state");
        player = trailLogic.gameObject;
    }

    public override EnemyStateMachine.EnemyState GetNextState()
    {
       return EnemyStateMachine.EnemyState.Patrol;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trailLogic.BeingAttacked();
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trailLogic.AttackStopped();
        }
    }

    public override void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trailLogic.ReduceTrail(damage);
        }
    }

    public override void UpdateState()
    {
        rb.velocity = (player.transform.position - rb.position).normalized * speed;
    }
}
