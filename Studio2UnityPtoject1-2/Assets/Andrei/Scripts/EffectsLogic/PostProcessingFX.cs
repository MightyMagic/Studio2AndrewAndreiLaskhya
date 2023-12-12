using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingFX : MonoBehaviour
{
   
    [SerializeField] PostProcessVolume volume;
    [SerializeField] float vignetteSpeed;
    [SerializeField] GameObject playerObject;
    float timer;

    [SerializeField] TrailLogic trailLogic;
    bool effectStarted;

    void Start()
    {
        trailLogic = playerObject.GetComponent<TrailLogic>();
        volume.weight = 0f;

        timer = 0f;
        effectStarted = false;
       // vignette.intensity = 0f;
    }

    void Update()
    {
        if(!effectStarted && trailLogic.inDarkness)
        {
            effectStarted = true;
        }
        else if(effectStarted && !trailLogic.inDarkness)
        {
            timer = 0f;
            //vignette.intensity = 0f;
            effectStarted = false;
        }

        if(effectStarted)
        {
            if(volume.weight < 1f)
            {
                volume.weight += vignetteSpeed * Time.deltaTime;
            }
        }

        if(volume.weight > 0f && !effectStarted)
        {
            if(volume.weight > 0f)
            {
                volume.weight -= 3 * vignetteSpeed * Time.deltaTime;
            }
            else
                volume.weight = 0f;
        }



    }

    void AdjustVignette()
    {

    }
}
