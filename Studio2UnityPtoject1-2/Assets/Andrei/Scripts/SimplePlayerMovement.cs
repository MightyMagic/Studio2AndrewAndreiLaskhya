using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    Rigidbody playerRb;
    Vector3 camOffset;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        camOffset = - transform.position + Camera.main.transform.position;
    }

    void Update()
    {
        float inputValueSide = Input.GetAxisRaw("Horizontal");
        float inputValueForward = Input.GetAxisRaw("Vertical");

        //print("Vertical is " + inputValueForward);

        playerRb.velocity = (transform.forward * inputValueForward + transform.right * inputValueSide).normalized * moveSpeed;

        
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = camOffset + transform.position;
    }
}
