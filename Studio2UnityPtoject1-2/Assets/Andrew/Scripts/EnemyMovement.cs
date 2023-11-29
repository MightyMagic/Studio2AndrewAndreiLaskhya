using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// Current object components
    /// </summary>
    [SerializeField] Collider triggerRadius;
    [SerializeField] Rigidbody rb;

    /// <summary>
    /// Player variables
    /// </summary>
    [SerializeField] Transform playerTransform;

    /// <summary>
    /// Enemy movement values
    /// </summary>
    [SerializeField] float steeringSpeed = 150;
    [SerializeField] float maxSpeed = 5;

    /// <summary>
    /// Movement for patrol state
    /// </summary>
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float rotateSpeed = 150;

    public enum EnemyState
    {
        Patrol,
        Chase,
    }

    private EnemyState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentState = EnemyState.Patrol;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                UpdatePatrolState();
                break;

            case EnemyState.Chase:
                UpdateChaseState();
                break;
        }
    }

    private void SetPatrolState()
    {
        currentState = EnemyState.Patrol;
    }

    private void SetChaseState()
    {
        currentState = EnemyState.Chase;
    }

    private void UpdatePatrolState()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, UnityEngine.Random.Range(-1f, 1f) * rotateSpeed * Time.deltaTime, 0));

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, transform.position.x - 10, transform.position.x + 10);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, transform.position.z - 10, transform.position.z + 10);
        transform.position = clampedPosition;
    }

    private void UpdateChaseState()
    {
        Vector3 direction = playerTransform.position - transform.position;
        Vector3 normalizedDirection = direction.normalized;
        rb.velocity += normalizedDirection * steeringSpeed * Time.deltaTime;

        if (rb.velocity.magnitude >= maxSpeed)
        {
            Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetChaseState();
        }
        else
        {
            SetPatrolState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SetPatrolState();
    }
}
