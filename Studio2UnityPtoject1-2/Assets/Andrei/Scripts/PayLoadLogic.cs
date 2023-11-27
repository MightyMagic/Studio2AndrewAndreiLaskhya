using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayLoadLogic : MonoBehaviour
{
    [SerializeField] float payloadHealth;
    [SerializeField] float payloadPercentLossPerSecond;

    GameObject lightObject;
    Light lightComponent;
    float initialLightRange;
    Vector3 initialScale;

    public float currentHealth;

    public bool inDarkness;


    void Start()
    {
        inDarkness= true;
        currentHealth = payloadHealth;

        lightObject = transform.GetChild(0).gameObject;
        lightComponent = lightObject.transform.GetChild(0).GetComponent<Light>();

        initialScale = lightObject.transform.localScale;
        initialLightRange = lightComponent.range;
    }

    void Update()
    {
        if(inDarkness)
        {
            DecreaseHealth();
        }
    }

    void DecreaseHealth()
    {
        if(currentHealth > 20f)
        {
            currentHealth -= payloadHealth * payloadPercentLossPerSecond * Time.deltaTime * 0.01f;
            lightObject.transform.localScale = initialScale * (currentHealth / payloadHealth);
            lightComponent.range = initialLightRange * (currentHealth / payloadHealth);
        }
        else
        {
            return;
        }
    }
    public void RestoreHealth()
    {
        currentHealth = payloadHealth;
        lightObject.transform.localScale = initialScale;
        lightComponent.range = initialLightRange;
    }
}
