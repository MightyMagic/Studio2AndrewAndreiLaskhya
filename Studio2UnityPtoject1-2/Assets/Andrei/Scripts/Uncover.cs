using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncover : MonoBehaviour
{
    [SerializeField] List<GameObject> children;
    [SerializeField] float delayBeforeFade;

    [SerializeField] bool switchesNewTarget;
    [SerializeField] HintTrailsManager hintTrailsManager;
    void Start()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            Reveal(true);

            if(switchesNewTarget)
            {
                hintTrailsManager.SwitchObjective();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            
        }
    }

    void Reveal(bool isRevealed)
    {
        if(isRevealed)
        {
            //StopAllCoroutines();
            foreach (GameObject child in children)
            {
                child.SetActive(true);
            }
        }
        else
        {
            //StartCoroutine(DelayBeforeFade());
            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }
        }
    }

    private IEnumerator DelayBeforeFade()
    {
        print("Disabling the objects");
        yield return new WaitForSeconds(delayBeforeFade);
    }
}
