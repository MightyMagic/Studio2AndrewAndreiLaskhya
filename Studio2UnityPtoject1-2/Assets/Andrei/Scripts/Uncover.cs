using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncover : MonoBehaviour
{
    [SerializeField] List<GameObject> children;
    void Start()
    {
        Reveal(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            Reveal(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PayLoad")
        {
            Reveal(false);
        }
    }

    void Reveal(bool isRevealed)
    {
        if(isRevealed)
        {
            foreach (GameObject child in children)
            {
                child.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject child in children)
            {
                child.SetActive(false);
            }
        }
    }
}
