using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collet : MonoBehaviour
{
    public GameObject movingPlatform;
    public int requiredItems = 3;
    private int collectedItems = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectedItems++;

            if (collectedItems >= requiredItems)
            {
                ActivatePlatform();
            }

            gameObject.SetActive(false);
        }
    }

    private void ActivatePlatform()
    {
        if (movingPlatform != null)
        {
            movingPlatform.GetComponent<MovingPlatform>().Activate();
        }
    }
}