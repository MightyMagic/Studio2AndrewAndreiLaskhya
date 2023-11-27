using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpTrigger : MonoBehaviour
{
    PayLoadLogic payload;
    void Start()
    {
        payload = transform.parent.GetComponent<PayLoadLogic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EMP")
        {
            payload.RestoreHealth();
        }
    }


}
