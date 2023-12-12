using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailLogic : MonoBehaviour
{

    [SerializeField] ParticleSystem trail;
    Animator trailAnimator;
    float initialTrailSize;
    float initialLightIntensity;

    [SerializeField] float initialValue;
    [SerializeField] float lossPerSecond;
    public bool inDarkness;

    [SerializeField] Light playerLight;
    [SerializeField] float minLightRange;
    float lightRangeToTurnRed;

    [SerializeField] Color dangerousColor;
    [SerializeField] Color safeColor;
    bool inDanger;

    //[SerializeField] GameObject sphereAura;
    float sphereSize;
    float sphereInitialSize;


    [SerializeField] string sceneToLoad;


    float lightRange;

    public float startTrail;
    float loss;
    void Start()
    {
        trailAnimator = trail.gameObject.GetComponent<Animator>();
        initialTrailSize = trail.gameObject.transform.localScale.x;
        trailAnimator.enabled = false;

        initialLightIntensity = playerLight.intensity;

        trail.startLifetime = initialValue;
        startTrail = trail.startLifetime;
        inDarkness= false;

        lightRange = playerLight.range - minLightRange;

        lightRangeToTurnRed = minLightRange + lightRange / 3f;

        inDanger= false;

        Cursor.lockState = CursorLockMode.Locked;

        //sphereInitialSize = sphereAura.transform.localScale.x;
        //sphereSize = sphereInitialSize;
    }

    void Update()
    {
        if(inDarkness)
        {
            startTrail = startTrail - lossPerSecond * Time.deltaTime;

            trail.startLifetime = startTrail;

            playerLight.range = minLightRange + (startTrail / initialValue) * lightRange;

           // sphereSize = sphereInitialSize - lossPerSecond * sphereInitialSize * Time.deltaTime;
            //sphereAura.transform.localScale = Vector3.one * sphereSize;
        }

        if (startTrail < 0f)
        {
            GameOver();
        }

        if(playerLight.range < lightRangeToTurnRed && !inDanger)
        {
            inDanger= true;       
            trailAnimator.enabled = true;
        }

        if (playerLight.range > lightRangeToTurnRed && inDanger)
        {
            inDanger = false;
            trailAnimator.enabled = false;
            ResetTrailSize();

           // sphereAura.transform.localScale = Vector3.one * sphereInitialSize;
        }

    }

    public void RestoreTrail()
    {
        startTrail = initialValue;
        playerLight.range = minLightRange + lightRange;
        playerLight.color = safeColor;
        trail.startColor = safeColor;
    }

    public void ReduceTrail(float coeff)
    {
        startTrail = startTrail - (coeff * lossPerSecond * Time.deltaTime);
        print("trail is affected" + startTrail);
    }

    public void BeingAttacked()
    {
        playerLight.color = dangerousColor;
        trail.startColor = dangerousColor;
    }

    public void AttackStopped()
    {
        playerLight.color = safeColor;
        trail.startColor = safeColor;
    }

    public void HideTrail(bool hide)
    {
        if (hide)
        {
            playerLight.intensity = initialLightIntensity * 0.8f;
            //playerLight.enabled= false;
        }
        else
        {
            playerLight.intensity = initialLightIntensity;
            //playerLight.enabled= true;
        }
    }

    void ResetTrailSize()
    {
        trail.transform.localScale = initialTrailSize * Vector3.one;
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
