using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///µ–»Àª˘¿‡
///</summary>
public enum EnemyType
{
    Elf,
    Orge,
    Troll
}

public abstract class IEnemy : ICharacter
{
    protected EnemyFSMSystem mFSMSystem;

    public IEnemy():base()
    {
        MakeFSM();
    }
    public void UpdateFSM(List<ICharacter> targets)
    {
        if (mIsKilled)
        {
            return;
        }
        mFSMSystem.currentState.Reason(targets);
        mFSMSystem.currentState.Act(targets);
    }
    private void MakeFSM()
    {
        mFSMSystem = new EnemyFSMSystem();

        EnemyChaseState enemyChaseState = new EnemyChaseState(mFSMSystem, this);
        enemyChaseState.AddTransition(EnemyTransition.CanAttack, EnemyStateId.AttackState);

        EnemyAttackState enemyAttackState = new EnemyAttackState(mFSMSystem, this);
        enemyAttackState.AddTransition(EnemyTransition.NoSoldierInsight, EnemyStateId.ChaseState);

        mFSMSystem.AddState(enemyChaseState, enemyAttackState);
    }
    public override void UnderAttack(int damage)
    {
        if (mIsKilled)
        {
            return;
        }
        base.UnderAttack(damage);
        PlayEffect();

        if(mAttr.CurrenHP <= 0)
        {
            Killed();
        }
    }
    public  abstract void PlayEffect();
    public override void Killed()
    {
        base.Killed();
        GameFacade.Instance.Notify(GameEventType.EnmeyKilled);
    }
    public override void RunVisitor(ICharacterVisitor chracterVisitor)
    {
        chracterVisitor.VisitEnemy(this);
    }
}
