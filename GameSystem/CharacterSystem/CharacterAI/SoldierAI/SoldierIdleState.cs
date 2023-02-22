using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierIdleState : ISoldierState
{
    public SoldierIdleState(SoldierFSMSystem fsm, ICharacter character) : base(fsm, character)
    {
        mStateId = SoldierStateId.Idle;
    }
    public override void Act(List<ICharacter> targets)
    {
        mCharacter.PlayAnim("stand");
    }

    public override void Reason(List<ICharacter> targets)
    {
        //发现敌人时切换状态
        if (targets != null && targets.Count > 0)
        { 
            mFSM.PerformTransition(SoldierTransition.SeeEnemy); 
        }
    }
}
