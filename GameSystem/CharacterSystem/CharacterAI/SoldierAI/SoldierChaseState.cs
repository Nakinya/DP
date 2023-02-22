using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierChaseState : ISoldierState
{
    public SoldierChaseState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateId = SoldierStateId.Chase;
    }

    public override void Act(List<ICharacter> targets)
    {
        if (targets != null && targets.Count > 0)
            mCharacter.MoveTo(targets[0].GetPosition());
    }

    public override void Reason(List<ICharacter> targets)
    {
        if (targets == null || targets.Count == 0)
        {
            mFSM.PerformTransition(SoldierTransition.NoEnemyInSight);
            return;
        }
        float distance = Vector3.Distance(targets[0].GetPosition(), mCharacter.GetPosition());
        if(distance <= mCharacter.AttackRange)
        {
            mFSM.PerformTransition(SoldierTransition.CanAttack);
        }
    }
}
