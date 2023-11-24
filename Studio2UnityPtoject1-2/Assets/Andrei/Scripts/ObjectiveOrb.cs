using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOrb : MonoBehaviour
{
    Portal portal;
    void Start()
    {
        portal = transform.parent.GetComponent<Portal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            portal.OrbActivated();
        }
    }

}
