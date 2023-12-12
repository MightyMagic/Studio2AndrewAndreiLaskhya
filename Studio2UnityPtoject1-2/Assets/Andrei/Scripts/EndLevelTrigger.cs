using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            if(playerData != null)
                playerData.ResetSave();
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
