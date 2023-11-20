using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 direction = Vector3.up;

    private bool activated = false;

    void Update()
    {
        if (activated)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void Activate()
    {
        activated = true;
    }
}
