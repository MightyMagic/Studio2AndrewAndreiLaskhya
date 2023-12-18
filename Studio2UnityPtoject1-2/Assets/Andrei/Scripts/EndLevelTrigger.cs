using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] SaveLoad saveLoad;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            saveLoad.ClearFileAndCashTxt();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
