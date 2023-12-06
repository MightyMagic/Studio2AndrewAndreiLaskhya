using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
