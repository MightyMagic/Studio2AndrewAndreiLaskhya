using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] SaveLoad saveLoad;
    [SerializeField] bool lanternNotPresent;

    [SerializeField] PauseMenuControl pauseMenu;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            saveLoad.ClearFileAndCashTxt();
            
            StartCoroutine(pauseMenu.FadeIn(sceneToLoad));
            
            //SceneManager.LoadScene(sceneToLoad);
        }

        //if (other.gameObject.tag == "Player" && lanternNotPresent)
        //{
        //    saveLoad.ClearFileAndCashTxt();
        //    
        //    
        //    StartCoroutine(pauseMenu.FadeIn(sceneToLoad));
        //    
        //    //SceneManager.LoadScene(sceneToLoad);
        //}

    }
}
