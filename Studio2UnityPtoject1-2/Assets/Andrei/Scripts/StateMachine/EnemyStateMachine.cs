using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine<EnemyStateMachine.EnemyState>
{
    [Header("Refs")]
    [SerializeField] TrailLogic trailLogic;
    [SerializeField] GameObject player;
    [SerializeField] float damage;
    [SerializeField] float activationDistance;

    [SerializeField] float speed;
    [SerializeField] GameObject waypointsObject;

    [Header("Internal")]
    Dictionary<EnemyState, BaseState<EnemyState>> states = new Dictionary<EnemyState, BaseState<EnemyState>>();
    bool isPatrolling;
    Rigidbody rb;
   


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPatrolling = true;

        EnemyPatrolState patrolState = new EnemyPatrolState(speed, waypointsObject, rb, this.gameObject);
        EnemyAttackState attackState = new EnemyAttackState(speed, waypointsObject, damage, trailLogic, rb);

        states.Add(EnemyState.Patrol, patrolState);
        states.Add(EnemyState.Attack,attackState);

        currentState = states[EnemyState.Patrol];
        currentState.EnterState();
    }


    void Update()
    {
        //nextStateKey = currentState.GetNextState();
       // if (nextStateKey.Equals(currentState.stateKey) && !isTransitioning)
       // {
       //     currentState.UpdateState();
       // }
       // else if (!isTransitioning)
       // {
       //     TransitionToState(nextStateKey);
       // }
        currentState.UpdateState();
        //print("Distance now is " + (player.transform.position - this.transform.position).magnitude + "Current state is " + currentState.name);
       
        if (trailLogic.inDarkness && ((player.transform.position - this.transform.position).magnitude < activationDistance) && isPatrolling)
        {
            //nextStateKey = currentState.GetNextState();
            //currentState = states[currentState.GetNextState()];
            isPatrolling= false;
            print("Switching to Attack!");
            TransitionToState(EnemyState.Attack);
        }       
        else if (!trailLogic.inDarkness && !isPatrolling)
        {
            //nextStateKey = currentState.GetNextState();
            //currentState = states[currentState.GetNextState()];
            isPatrolling = true;
            print("Switching to Patrol");
            trailLogic.AttackStopped();
            TransitionToState(EnemyState.Patrol);
        }
    }

    public void TransitionToState(EnemyState stateKey)
    {
        isTransitioning = true;
     
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioning = false;
    }

    public enum EnemyState
    {
        Patrol,
        Attack
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }

    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }
}


