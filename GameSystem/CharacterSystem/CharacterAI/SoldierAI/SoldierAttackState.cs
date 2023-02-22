using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierAttackState : ISoldierState
{
    private float mAttackCoolDownTime = 1f;
    private float mCurrentAttackTime = 1f;
    public SoldierAttackState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateId = SoldierStateId.Attack;
        mCurrentAttackTime = mAttackCoolDownTime;
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
            return;
        mCharacter.NavMeshAgent.isStopped = true;
        mCurrentAttackTime += Time.deltaTime;
        if(mCurrentAttackTime >= mAttackCoolDownTime)
        {
            mCharacter.Attack(targets[0]);
            mCurrentAttackTime = 0f;
        }
    }
    public override void Reason(List<ICharacter> targets)
    {
        if(targets == null || targets.Count == 0)
        {
            mCharacter.NavMeshAgent.isStopped = false;
            mFSM.PerformTransition(SoldierTransition.NoEnemyInSight);
            return;
        }
        float distance = Vector3.Distance(mCharacter.GetPosition(), targets[0].GetPosition());
        if (distance > mCharacter.AttackRange)
        {
            mCharacter.NavMeshAgent.isStopped = false;
            mFSM.PerformTransition(SoldierTransition.SeeEnemy);
        }
    }
}
