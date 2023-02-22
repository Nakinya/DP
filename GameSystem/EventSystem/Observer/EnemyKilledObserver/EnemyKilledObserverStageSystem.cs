using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///处理关卡系统观察者行为
///</summary>
public class EnemyKilledObserverStageSystem : IGameEventObserver
{
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;
    public EnemyKilledObserverStageSystem(StageSystem stageSystem)
    {
        mStageSystem = stageSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as EnemyKilledSubject;
    }
    public override void Update()
    {
        mStageSystem.NumOfEnemyKilled = mSubject.EnemyKilledNum;
    }
}
