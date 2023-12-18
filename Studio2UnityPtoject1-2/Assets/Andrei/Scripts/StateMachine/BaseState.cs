using System;
using UnityEngine;

public abstract class BaseState<Estate>: ObserverSubject
{

    public BaseState(Estate key)
    {
        stateKey= key;
    }

    public Estate stateKey;

    public abstract void EnterState();
   // public abstract void ExitState();
    public abstract void UpdateState();
    public abstract Estate GetNextState();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerExit(Collider other);
    public abstract void OnTriggerStay(Collider other);

}
