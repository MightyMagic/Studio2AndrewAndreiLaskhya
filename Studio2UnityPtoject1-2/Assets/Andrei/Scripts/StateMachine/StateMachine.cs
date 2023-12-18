using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<Estate> : MonoBehaviour
{
    private Dictionary<Estate, BaseState<Estate>> states = new Dictionary<Estate, BaseState<Estate>>();

    protected BaseState<Estate> currentState;
    protected Estate nextStateKey;

    protected bool isTransitioning = false;


    void Start()
    {
        //currentState.EnterState(); 
    }

    
    void Update()
    {
        //nextStateKey = currentState.GetNextState();
        //if(nextStateKey.Equals(currentState.stateKey) && !isTransitioning )
        //{
        //    currentState.UpdateState();
        //}
        //else if(!isTransitioning)
        //{
        //    TransitionToState(nextStateKey);
        //}
    }

    public void TransitionToState(Estate stateKey)
    {
        isTransitioning = true;
        currentState = states[stateKey];
        currentState.EnterState();
        isTransitioning= false;
    }
}
