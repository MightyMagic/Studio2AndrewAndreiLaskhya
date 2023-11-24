using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] List<GameObject> objectiveOrbs;
    [SerializeField] string sceneToLoad;
    GameObject portalObject;


    public int orbCount;

    void Start()
    {
        portalObject = transform.Find("Portal").gameObject;
        orbCount = objectiveOrbs.Count;
        portalObject.gameObject.SetActive(false);
    }

    void Update()
    {
        if(orbCount == 0)
        {
            Debug.Log("Activated the portal");
            portalObject.gameObject.SetActive(true);
        }
    }

    public void LoadNewScene()
    {
        Debug.Log("Loading new scene");
    }
  

    public void OrbActivated()
    {
        orbCount--;
    }
}
