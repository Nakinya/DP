using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;
    public SoldierKilledObserverAchievement(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        return;
    }

    public override void Update()
    {
        mAchievementSystem.AddSoldierKilledCount();
    }
}
