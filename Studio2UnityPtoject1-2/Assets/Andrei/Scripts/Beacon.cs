using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TrailLogic>().inDarkness = false;
            other.gameObject.GetComponent<TrailLogic>().RestoreTrail();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           other.gameObject.GetComponent<TrailLogic>().inDarkness = true;
        }
    }



}
