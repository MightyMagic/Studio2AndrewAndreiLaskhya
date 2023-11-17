using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] float upwardSpeed;

    [SerializeField] GameObject emp;

    TrailLogic trail;

    Rigidbody playerRb;
    Vector3 camOffset;

    Vector3 currentVelocity;

    float timeKeyPressed;
    bool spacePressed;

    void Start()
    {
        emp.SetActive(false);

        playerRb = GetComponent<Rigidbody>();
        camOffset = - transform.position + Camera.main.transform.position;

        trail = GetComponent<TrailLogic>();

        spacePressed= false;
    }

    void Update()
    {
        float inputValueSide = Input.GetAxisRaw("Horizontal");
        float inputValueForward = Input.GetAxisRaw("Vertical");

        currentVelocity = (transform.forward * inputValueForward + transform.right * inputValueSide).normalized * moveSpeed;

       
        playerRb.velocity = new Vector3(currentVelocity.x, playerRb.velocity.y, currentVelocity.z);
        

        if (Time.time - timeKeyPressed > 0.3f && spacePressed)
        {
            if(trail.inDarkness)
            {
                playerRb.velocity = new Vector3(currentVelocity.x, upwardSpeed, currentVelocity.z);
                trail.ReduceTrail(2f);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeKeyPressed = Time.time;
            spacePressed = true;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            if(trail.inDarkness && (Time.time - timeKeyPressed < 0.2f))
            {
                StartCoroutine(EMP());
            }

            timeKeyPressed = 0f;
            spacePressed= false;
        }
    }

    IEnumerator EMP()
    {
       
        if (trail.EmpEnergy(0.25f))
        {
            emp.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            emp.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = camOffset + transform.position;
    }
}
