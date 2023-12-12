using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;

    public PatrolState PatrolState = new PatrolState();
    public ChaseState ChaseState = new ChaseState();
    public FleeState FleeState = new FleeState();

    [SerializeField] Transform playerTransform;
    public Transform PlayerTransform => playerTransform;

    private Rigidbody body;
    public Rigidbody Body => body;

    [SerializeField] float distancetochase = 30;

    public float DistanceToChase => distancetochase;

    public float steeringSpeed = 150;
    public float maxSpeed = 5;

    public Transform playerForward;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();

        currentState = ChaseState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;

        state.EnterState(this);
    }

    //private void OnTriggerEnter(Collider other)
    //{
        //if (other.CompareTag("Player"))
        //{
            //currentState = ChaseState;

            //currentState.EnterState(this);
        //}
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, DistanceToChase);
    }
}
