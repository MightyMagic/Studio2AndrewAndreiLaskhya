using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyPatrolState : BaseState<EnemyStateMachine.EnemyState>
{
    [Header("Refs")]
    private float speed;
    private GameObject waypointsObject;
    private GameObject enemyObject;
    private float activationDistance;


    [Header("Internal")]
    Rigidbody rb;
    bool isStunned;
    float timer;

    bool patrolling;
    private int currentIndex;


    private List<GameObject> waypoints = new List<GameObject>();


    public EnemyPatrolState(float speed, GameObject waypointsObject, Rigidbody rb, GameObject enemyObject) : base(EnemyStateMachine.EnemyState.Patrol)
    {
        this.speed = speed;
        this.waypointsObject = waypointsObject;
        this.rb = rb;
        this.enemyObject = enemyObject;
    }

    public override void EnterState()
    {
        Debug.Log("Entered patrol state");
        Waypoints waypointsScript = waypointsObject.GetComponent<Waypoints>();
        waypoints = waypointsScript.waypoints;
        print("Fetched this many waypoints" + waypoints.Count);
        currentIndex = FindClosestNode();
        

        isStunned = false;
        timer = 0f;
    }

    public override EnemyStateMachine.EnemyState GetNextState()
    {
       return EnemyStateMachine.EnemyState.Attack;
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public override void OnTriggerExit(Collider other)
    {
        
    }

    public override void OnTriggerStay(Collider other)
    {
        
    }

    public override void UpdateState()
    {
        Patrolling();
    }

    private void Patrolling()
    {
        if ((waypoints[currentIndex].transform.position - rb.position).magnitude > (enemyObject.transform.lossyScale.x))
        {
            MoveToWapoint(currentIndex);
        }
        else
        {
            currentIndex = (currentIndex + 1) % waypoints.Count;
        }
    }

    private void MoveToWapoint(int index)
    {
        rb.velocity = (waypoints[index].transform.position - rb.position).normalized * speed;
    }

    private int FindClosestNode()
    {
        float closestDistance = Mathf.Infinity;
        int closestIndex = 0;

        for (int i = 0; i < waypoints.Count; i++)
        {
            if (waypoints[i] != null)
            {
                float distance = Vector3.Distance(rb.position, waypoints[i].transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
        }

        return closestIndex;
    }
}
