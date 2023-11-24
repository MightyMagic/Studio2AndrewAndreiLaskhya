using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] float speed;

    GameObject player;
    TrailLogic trailLogic;

    [SerializeField] float stunTime;

    Rigidbody rb;
    bool isStunned;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerSphere");
        trailLogic = player.GetComponent<TrailLogic>();

        isStunned= false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStunned)
        {
            rb.velocity = (player.transform.position - rb.position).normalized * speed;
        }

        if (isStunned)
        {
            timer += Time.deltaTime;
            rb.velocity = Vector3.zero;
        }

        if(timer > stunTime)
        {
            timer = 0f;
            isStunned= false;
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
           trailLogic.GameOver();
        }
    }
}
