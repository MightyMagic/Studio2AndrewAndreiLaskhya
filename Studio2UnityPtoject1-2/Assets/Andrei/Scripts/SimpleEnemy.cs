using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] GameObject waypointsObject;
    private List<GameObject> waypoints = new List<GameObject>();

    GameObject player;
    TrailLogic trailLogic;

    [SerializeField] float stunTime;
    [SerializeField] float activationDistance;


    Rigidbody rb;
    bool isStunned;
    float timer;

    bool patrolling;
    public int currentIndex;


    void Start()
    {
        patrolling = true;

        rb= GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerSphere");
        trailLogic = player.GetComponent<TrailLogic>();

        Waypoints waypointsScript = waypointsObject.GetComponent<Waypoints>();
        waypoints = waypointsScript.waypoints;
        print("Fetched this many waypoints" + waypoints.Count);
        currentIndex = FindClosestNode();

        isStunned = false;
        timer = 0f;
    }

    void Update()
    {
       
        if(patrolling)
        {
            Patrolling();
        }
        else
        {
            rb.velocity = (player.transform.position - rb.position).normalized * speed;
        }
      
        if(trailLogic.inDarkness && patrolling && (player.transform.position - this.transform.position).magnitude < activationDistance)
        {
            patrolling= false;
        }
        else if(!trailLogic.inDarkness && !patrolling)
        {
            patrolling = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EMP")
        {
            isStunned= true;
        }

        if (other.gameObject.tag == "Player")
        {
            trailLogic.BeingAttacked();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trailLogic.ReduceTrail(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           trailLogic.AttackStopped();
        }
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

    private void Patrolling()
    {
        if((waypoints[currentIndex].transform.position - rb.position).magnitude > (transform.lossyScale.x))
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }


}
