using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameEventType
{
    Null,
    EnmeyKilled,
    SoldierKilled,
    NewStage
}
///<summary>
///游戏主题管理类
///</summary>
public class EventSystem : IGameSystem
{
    private Dictionary<GameEventType, IGameEventSubject> mGameEvents = new Dictionary<GameEventType, IGameEventSubject>();

    public override void Init()
    {
        base.Init();
        InitGameEvents();
    }
    private void InitGameEvents()
    {
        mGameEvents.Add(GameEventType.EnmeyKilled, new EnemyKilledSubject());
        mGameEvents.Add(GameEventType.SoldierKilled, new SoldierKilledSubject());
        mGameEvents.Add(GameEventType.NewStage, new NewStageSubject());
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        if (!mGameEvents.ContainsKey(eventType))
        {
            Debug.LogError("No such event in game events dictionary!");
            return;
        }
        IGameEventSubject subject = mGameEvents[eventType];
        subject.RegisterObservers(observer);
        observer.SetSubject(subject);
    }
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        if (!mGameEvents.ContainsKey(eventType))
        {
            Debug.LogError("No such event in game events dictionary!");
            return;
        }
        IGameEventSubject subject = mGameEvents[eventType];
        subject.RemoveObserver(observer);
        observer.SetSubject(null);
    }
    public void Notify(GameEventType eventType)
    {
        if (!mGameEvents.ContainsKey(eventType))
        {
            Debug.LogError("No such event in game events dictionary!");
            return;
        }
        IGameEventSubject subject = mGameEvents[eventType];
        subject.Notify();
    }
}
