using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;
    public EnemyKilledObserverAchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }
    public override void Update()
    {
        mAchievementSystem.AddEnemyKilledCount();
    }

    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }
}
