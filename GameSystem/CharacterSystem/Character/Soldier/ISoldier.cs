using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///士兵基类
///</summary>
public enum SoldierType
{
    Rookie,
    Sergeant,
    Captain,
    Captive
}

public abstract class ISoldier : ICharacter
{
    protected SoldierFSMSystem mFSMSystem;
    public ISoldier(): base()
    {
        MakeFSM();
    }

    //创建士兵状态机系统
    private void MakeFSM()
    {
        mFSMSystem = new SoldierFSMSystem();

        SoldierIdleState idleState = new SoldierIdleState(mFSMSystem, this);
        idleState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateId.Chase);

        SoldierChaseState chaseState = new SoldierChaseState(mFSMSystem, this);
        chaseState.AddTransition(SoldierTransition.NoEnemyInSight, SoldierStateId.Idle);
        chaseState.AddTransition(SoldierTransition.CanAttack, SoldierStateId.Attack);

        SoldierAttackState attackState = new SoldierAttackState(mFSMSystem, this);
        attackState.AddTransition(SoldierTransition.NoEnemyInSight, SoldierStateId.Idle);
        attackState.AddTransition(SoldierTransition.SeeEnemy, SoldierStateId.Chase);

        mFSMSystem.AddState(idleState, chaseState, attackState);
    }

    //游戏循环中做状态机逻辑处理
    public void UpdateFSM(List<ICharacter> targets)
    {
        if (mIsKilled)
        {
            return;
        }
        mFSMSystem.currentState.Act(targets);
        mFSMSystem.currentState.Reason(targets);
    }
    public override void UnderAttack(int damage)
    {
        if (mIsKilled)
        {
            return;
        }
        base.UnderAttack(damage);
        if (mAttr.CurrenHP <= 0)
        {
            PlayEffect();
            PlaySound();
            Killed();
        }
    }
    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.Notify(GameEventType.SoldierKilled);
    }
    protected  abstract void PlaySound();
    protected abstract void PlayEffect();

    public override void RunVisitor(ICharacterVisitor chracterVisitor)
    {
        chracterVisitor.VisitSoldier(this);
    }
}
