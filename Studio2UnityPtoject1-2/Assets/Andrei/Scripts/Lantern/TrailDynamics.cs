using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDynamics : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float acceleration;
    [SerializeField] float timeBetweenImpulses;

    [SerializeField] GameObject trailsControl;
    HintTrailsManager hintTrailsManager;

    ParticleSystem hintTrail;

    Transform target;
    bool isSent;
    float timer;
    int index = 0;
    void Start()
    {
        hintTrail = GetComponent<ParticleSystem>();

        hintTrailsManager = trailsControl.GetComponent<HintTrailsManager>();

        timer = 0f;
        isSent= false;
        target = hintTrailsManager.FetchObjective();
        print("Target: " + target.name);
    }

    void Update()
    {
        MoveToTarget(target);
    }

    void MoveToTarget(Transform target)
    {
        Vector3 direction = (target.transform.position - this.transform.position);
        if (direction.magnitude > 5f)
        {
            direction = direction.normalized;
            this.transform.position += (direction * speed * Time.deltaTime + direction * Time.deltaTime * acceleration * (Time.time - timer) * (Time.time - timer) / 2f);
        }
        else
        {
            StartCoroutine(RechargeAndGO());
        }
    }

    IEnumerator RechargeAndGO()
    {
        hintTrail.Stop();
        yield return new WaitForSeconds(timeBetweenImpulses);
        hintTrail.Play();
        transform.position = transform.parent.position;
        timer = Time.time;
        target = hintTrailsManager.FetchObjective();
    }

}
