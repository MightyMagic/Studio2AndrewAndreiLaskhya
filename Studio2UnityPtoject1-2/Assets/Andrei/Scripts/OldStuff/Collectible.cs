using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float amountToRestore;

    bool active;
    MeshRenderer mesh;
    Collider collectibleCollider;
    float timer;

    private void Start()
    {
        timer = 0f;
        active = true;

        collectibleCollider= GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(!active)
        {
            timer += Time.deltaTime;
        }

        if(timer > amountToRestore)
        {
            timer= 0f;
            Refresh();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<TrailLogic>().RestoreTrail();
            active= false;

            mesh.enabled = false;
            collectibleCollider.enabled = false;
            //Destroy(this.gameObject);
        }
    }

    void Refresh()
    {
        mesh.enabled = true;
        collectibleCollider.enabled = true;
    }

}
