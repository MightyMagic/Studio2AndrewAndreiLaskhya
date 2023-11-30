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
    float lightRangeToTurnRed;

    [SerializeField] Color dangerousColor;
    [SerializeField] Color safeColor;
    bool inDanger;


    [SerializeField] string sceneToLoad;


    float lightRange;

    public float startTrail;
    float loss;
    void Start()
    {
        trail.startLifetime = initialValue;
        startTrail = trail.startLifetime;
        inDarkness= false;

        lightRange = playerLight.range - minLightRange;

        lightRangeToTurnRed = minLightRange + lightRange / 3f;

        inDanger= false;
    }

    void Update()
    {
        if(inDarkness)
        {
            startTrail = startTrail - lossPerSecond * Time.deltaTime;

            trail.startLifetime = startTrail;

            playerLight.range = minLightRange + (startTrail / initialValue) * lightRange;
        }

        if (startTrail < 0f)
        {
            GameOver();
        }

        if(playerLight.range < lightRangeToTurnRed && !inDanger)
        {
            inDanger= true;
            playerLight.color = dangerousColor;
            trail.startColor= dangerousColor;
        }

        if (playerLight.range > lightRangeToTurnRed && inDanger)
        {
            inDanger = false;
            playerLight.color = safeColor;
            trail.startColor = safeColor;
        }

    }

    public void RestoreTrail()
    {
        startTrail = initialValue;
        playerLight.range = minLightRange + lightRange;
    }

    public void ReduceTrail(float coeff)
    {
        startTrail = startTrail - (coeff * lossPerSecond * Time.deltaTime);
        print(coeff);
    }

    public void HideTrail(bool hide)
    {
        if (hide)
        {
            playerLight.enabled= false;
        }
        else
        {
            playerLight.enabled= true;
        }
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
    }
}
