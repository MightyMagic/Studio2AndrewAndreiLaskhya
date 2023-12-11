using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract method is a blueprint for new classes, providing methods
/// and variables to deriving classes
/// Can add constraints to generics for them to only apply to a certain class
/// or interface
/// </summary>
public abstract class BaseState<T> where T : Enum
{
    /// <summary>
    /// Abstract declaration in abstract state must be defined in deriving
    /// class
    /// </summary>

    public BaseState(T key)
    {
        StateKey = key;
    }

    /// <summary>
    /// Member variable
    /// </summary>
    public T StateKey { get; private set; }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    /// <summary>
    /// Generics are placeholders for when you want to instantiate the
    /// method, you can specify it's type
    /// Allows you to use the method with a different type, without needing to
    /// replicate code
    /// </summary>
    /// <returns></returns>
    public abstract T SwitchState();
    public abstract void OnTriggerEnter();
    public abstract void OnTriggerStay();
    public abstract void OnTriggerExit();
}
