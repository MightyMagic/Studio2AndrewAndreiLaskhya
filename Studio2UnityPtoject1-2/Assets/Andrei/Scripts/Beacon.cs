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
            other.gameObject.GetComponent<TrailLogic>().HideTrail(true);
        }

        if (other.gameObject.tag == "PayLoad" && other.gameObject.GetComponent<PayLoadLogic>() != null)
        {
         
            other.gameObject.GetComponent<PayLoadLogic>().EnteredBeacon();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           other.gameObject.GetComponent<TrailLogic>().inDarkness = true;
           other.gameObject.GetComponent<TrailLogic>().HideTrail(false);
        }
        if (other.gameObject.tag == "PayLoad" && other.gameObject.GetComponent<PayLoadLogic>() != null)
        {
            other.gameObject.GetComponent<PayLoadLogic>().LeftBeacon();
        }
    }



}
