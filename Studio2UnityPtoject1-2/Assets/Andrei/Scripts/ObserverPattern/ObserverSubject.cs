using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObserverSubject : MonoBehaviour
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    protected void NotifyObesrvers(SoundAction soundAction)
    {
        observers.ForEach((observer) => { observer.OnNotify(soundAction); });
    }
}
