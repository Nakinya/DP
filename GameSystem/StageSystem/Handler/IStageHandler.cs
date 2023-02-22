using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class IStageHandler
{
    protected int mLevel;//��ǰ�ؿ�
    protected int mEnemyKilledForStage;//ÿһ���ۼ�Ҫ��ɱ�ĵ�������
    protected StageSystem mStageSystem;
    protected IStageHandler mNextHandler;
    public IStageHandler(StageSystem stageSystem, int level, int enemyKilledForStage)
    {
        mLevel = level;
        mEnemyKilledForStage = enemyKilledForStage;
        mStageSystem = stageSystem;
    }
    public IStageHandler SetNextHandler(IStageHandler handler)
    {
        mNextHandler = handler;
        return handler;
    }
    public void Handle(int level)
    {
        if (level == mLevel)
        {
            UpdateStage();
            CheckStageFinished();
        }
        else
        {
            mNextHandler.Handle(level);
        }
    }
    protected virtual void UpdateStage()
    {

    }
    private void CheckStageFinished()
    {
        if (mStageSystem.NumOfEnemyKilled >= mEnemyKilledForStage)
        {
            mStageSystem.EnterNextStage();
        }
    }
}
