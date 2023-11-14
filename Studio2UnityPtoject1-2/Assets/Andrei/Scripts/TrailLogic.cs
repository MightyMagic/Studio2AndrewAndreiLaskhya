using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailLogic : MonoBehaviour
{
    [SerializeField] ParticleSystem trail;
    [SerializeField] float lossPerSecond;
    public bool inDarkness;

    public float startTrail;
    private float initialValue;
    float loss;
    // Start is called before the first frame update
    void Start()
    {
        startTrail = trail.startLifetime;
        inDarkness= false;

        initialValue = startTrail;
    }

    // Update is called once per frame
    void Update()
    {
        if(inDarkness)
        {
            startTrail = startTrail - lossPerSecond* Time.deltaTime;
            trail.startLifetime = startTrail;
        }
        else
        {
            startTrail = initialValue;
        }


    }
}
