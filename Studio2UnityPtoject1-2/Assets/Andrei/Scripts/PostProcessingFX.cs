using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingFX : MonoBehaviour
{
    Vignette vignette;
    [SerializeField] PostProcessVolume volume;
    [SerializeField] float vignetteSpeed;
    [SerializeField] GameObject playerObject;
    float timer;

    TrailLogic trailLogic;
    bool effectStarted;

    // Start is called before the first frame update
    void Start()
    {
        trailLogic = playerObject.GetComponent<TrailLogic>();
        volume.profile.TryGetSettings(out vignette);

        timer = 0f;
        effectStarted = false;
       // vignette.intensity = 0f;
    }

    // Update is called once per frame
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



    }

    void AdjustVignette()
    {

    }
}
