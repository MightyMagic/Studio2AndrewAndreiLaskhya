using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<T> : MonoBehaviour where T : Enum
{
    /// <summary>
    /// Protected is private, with the only classes allowed access being the ones deriving
    /// from it
    /// Dictionary will store the concrete states, the key type specifies which concrete state you access
    /// </summary>
    protected Dictionary<T, BaseState<T>> States = new Dictionary<T, BaseState<T>>();

    protected BaseState<T> CurrentState;

    protected bool isTransitioningState;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        T nextStateKey = CurrentState.SwitchState();

        if (!isTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if (!isTransitioningState)
        {
            TransitionToState(nextStateKey);
        }

        CurrentState.UpdateState();
    }

    public void TransitionToState(T stateKey)
    {
        isTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        isTransitioningState = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter();
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay();
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit();
    }
}
