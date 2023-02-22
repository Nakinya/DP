using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class NewStageSubject : IGameEventSubject
{
    private int mStageCount = 1;
    public int StageCount
    {
        get { return mStageCount; }
    }
    public override void Notify()
    {
        mStageCount++;
        if (mStageCount > 9)
        {
            mStageCount = 9;
        }
        base.Notify();
    }
}
