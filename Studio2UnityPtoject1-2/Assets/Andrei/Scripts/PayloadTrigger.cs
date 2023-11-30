using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PayloadTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

   // private void OnTriggerExit(Collider other)
   // {
   //     if (other.gameObject.tag == "PayLoad")
   //     {
   //        // child.SetActive(false);
   //     }
   // }
}
