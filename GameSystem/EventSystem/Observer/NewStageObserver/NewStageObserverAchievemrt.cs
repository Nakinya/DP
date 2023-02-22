using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class NewStageObserverAchievemrt : IGameEventObserver
{
    private AchievementSystem mAchievementSystem;
    private NewStageSubject mSubject; 
    public NewStageObserverAchievemrt(AchievementSystem achievementSystem)
    {
        mAchievementSystem = achievementSystem;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mAchievementSystem.SetMaxStageLevel(mSubject.StageCount);
    }
}
