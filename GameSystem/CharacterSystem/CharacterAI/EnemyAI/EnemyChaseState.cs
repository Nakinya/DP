using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyChaseState : IEnemyState
{
    private Vector3 mTargetPosition;
    public EnemyChaseState(EnemyFSMSystem enemyFSMSystem, ICharacter character): base(enemyFSMSystem, character)
    {
        mStateId = EnemyStateId.ChaseState;
    }
    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            mCharacter.MoveTo(targets[0].GetPosition());
        }
        else
        {
            mCharacter.MoveTo(mTargetPosition);
        }
    }
    public override void DoBeforeEntering()
    {
        mTargetPosition = GameFacade.Instance.GetEnemyTargetPosition();
    }
    public override void Reason(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
        {
            float distance = Vector3.Distance(mCharacter.GetPosition(), targets[0].GetPosition());
            if (distance <= mCharacter.AttackRange)
            {
                mFSM.PerformTransition(EnemyTransition.CanAttack);
            }
        }
    }
}
