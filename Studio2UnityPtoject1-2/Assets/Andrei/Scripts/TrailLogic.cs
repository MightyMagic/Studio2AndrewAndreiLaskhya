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

        lightRange = playerLight.range;
    }

    // Update is called once per frame
    void Update()
    {
        if(inDarkness)
        {
            startTrail = startTrail - lossPerSecond * Time.deltaTime;
        }


        trail.startLifetime = startTrail;

        playerLight.range = (startTrail / initialValue) * lightRange;


        if (startTrail < 0f)
        {
            GameOver();
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
