using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    [SerializeField] float distanceToDie;
    [SerializeField] TrailLogic trailLogic;

    float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y - initialY < -1 * distanceToDie)
        {
            trailLogic.GameOver();
        }
        
    }
}
