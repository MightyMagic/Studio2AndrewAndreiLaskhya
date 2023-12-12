using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrailsManager : MonoBehaviour
{
    [SerializeField] List<Transform> objectives;

    private int index;
    void Start()
    {
        index = 0;
    }

    void Update()
    {
        
    }

    public Transform FetchObjective()
    {
        if (index < objectives.Count)
        {
            return objectives[index];
        }
        else
        {
            return objectives[objectives.Count - 1];
        }
    }

    public void SwitchObjective()
    {
        index++;
    }
}
