using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBackgroundImage : MonoBehaviour
{
    [SerializeField] float magnitude;
    [SerializeField] float halfPeriod;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Animate();
    }

    void Animate()
    {
        if(timer < halfPeriod )
        {
            this.transform.localScale = Vector3.one + Vector3.one * (magnitude)  * (timer / halfPeriod); 
        }
        else if(timer > halfPeriod && timer < 2 * halfPeriod)
        {
            this.transform.localScale = Vector3.one * (1 + magnitude) - Vector3.one * (magnitude) * (timer - halfPeriod) /halfPeriod;
        }
        else if(timer > 2 * halfPeriod)
        {
            timer = 0f;
        }
    }
}
