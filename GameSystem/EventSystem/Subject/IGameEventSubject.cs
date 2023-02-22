using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class IGameEventSubject
{
    private List<IGameEventObserver> mObservers = new List<IGameEventObserver>();
    public void RegisterObservers(IGameEventObserver observer)
    {
        mObservers.Add(observer);
    }
    public void RemoveObserver(IGameEventObserver observer)
    {
        mObservers.Remove(observer);
    }
    public virtual void Notify()
    {
        foreach (IGameEventObserver observer in mObservers)
        {
            observer.Update();
        }
    }
}
