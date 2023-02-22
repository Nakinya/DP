using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class AchievementSystem : IGameSystem
{
    private int mEnemyKilled = 0;
    private int mSoldierKilled = 0;
    private int mMaxStageLevel = 1;
    public override void Init()
    {
        base.Init();
        GameFacade.Instance.RegisterObserver(GameEventType.EnmeyKilled, new EnemyKilledObserverAchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.SoldierKilled, new SoldierKilledObserverAchievement(this));
        GameFacade.Instance.RegisterObserver(GameEventType.NewStage, new NewStageObserverAchievemrt(this));
    }
    public void AddEnemyKilledCount(int number = 0)
    {
        mEnemyKilled += number;
    }
    public void AddSoldierKilledCount(int number = 0)
    {
        mSoldierKilled += number;
    }
    public void SetMaxStageLevel(int stageLevel)
    {
        if (stageLevel > mMaxStageLevel)
        {
            mMaxStageLevel = stageLevel;
        }
    }
   public AchievemenntMemento CreateMemento(int number = 1)
    {
        AchievemenntMemento memento = new AchievemenntMemento();
        memento.enemyKilledCount = mEnemyKilled;
        memento.soldierKilledCount = mSoldierKilled;
        memento.maxStageLevel = mMaxStageLevel;
        return memento;
    }
    public void SetMemento(AchievemenntMemento memento)
    {
        mEnemyKilled = memento.enemyKilledCount;
        mSoldierKilled = memento.soldierKilledCount;
        mMaxStageLevel = memento.maxStageLevel;
    }
}
