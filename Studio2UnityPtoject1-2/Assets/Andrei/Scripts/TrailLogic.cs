using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailLogic : MonoBehaviour
{

    [SerializeField] ParticleSystem trail;
    [SerializeField] float initialValue;
    [SerializeField] float lossPerSecond;
    public bool inDarkness;

    [SerializeField] Light playerLight;
    [SerializeField] float minLightRange;
    [SerializeField] Color dangerousColor;
    [SerializeField] Color safeColor;
    bool inDanger;


    [SerializeField] string sceneToLoad;


    float lightRange;

    public float startTrail;
    float loss;
    // Start is called before the first frame update
    void Start()
    {
        trail.startLifetime = initialValue;
        startTrail = trail.startLifetime;
        inDarkness= true;

        lightRange = playerLight.range - minLightRange;

        inDanger= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inDarkness)
        {
            startTrail = startTrail - lossPerSecond * Time.deltaTime;
        }


        trail.startLifetime = startTrail;

        playerLight.range = minLightRange + (startTrail / initialValue) * lightRange;


        if (startTrail < 0f)
        {
            GameOver();
        }

        if(playerLight.range < 7f && !inDanger)
        {
            inDanger= true;
            playerLight.color = dangerousColor;
            trail.startColor= dangerousColor;
        }

        if (playerLight.range > 7f && inDanger)
        {
            inDanger = false;
            playerLight.color = safeColor;
            trail.startColor = safeColor;
        }

    }

    public void RestoreTrail()
    {
        startTrail = initialValue;
    }

    public void ReduceTrail(float coeff)
    {
        startTrail = startTrail - (coeff * lossPerSecond * Time.deltaTime);
        print(coeff);
    }

    public bool EmpEnergy(float value)
    {
        if(startTrail - (initialValue * value) <0f)
        {
            //startTrail = 0f;
            print("Emp is on cooldown");
            return false;
        }
        else
        {
            startTrail = startTrail - (initialValue * value);
            return true;
        }
    }

    public void GameOver()
    {
        print("GameOver");
        SceneManager.LoadScene(sceneToLoad);
        //Destroy(this.gameObject);
    }
}
