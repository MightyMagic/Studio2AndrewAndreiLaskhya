using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTrigger : MonoBehaviour
{
    [SerializeField] SaveLoad saveLoad;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad" || other.gameObject.tag == "Player")
        {
            saveLoad.SavePosTxt();
        }
    }
}
