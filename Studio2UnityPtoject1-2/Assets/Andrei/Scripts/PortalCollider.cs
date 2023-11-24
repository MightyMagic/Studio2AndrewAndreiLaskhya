using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollider : MonoBehaviour
{
    Portal portal;

    private void Start()
    {
        portal = transform.parent.GetComponent<Portal>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            portal.LoadNewScene();

        }
    }
}
