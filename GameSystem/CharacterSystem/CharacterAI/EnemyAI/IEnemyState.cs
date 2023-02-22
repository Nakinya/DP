using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///敌人状态类
///</summary>
public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    NoSoldierInsight
}
public enum EnemyStateId
{
    NullState = 0,
    ChaseState,
    AttackState
}

public abstract class IEnemyState
{
    protected Dictionary<EnemyTransition, EnemyStateId> mMap = new Dictionary<EnemyTransition, EnemyStateId>();
    protected EnemyStateId mStateId;
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;
    public IEnemyState(EnemyFSMSystem enemyFSMSystem, ICharacter character)
    {
        mFSM = enemyFSMSystem;
        mCharacter = character;
    }
    public EnemyStateId stateId { get { return mStateId; } }

    public void AddTransition(EnemyTransition transition, EnemyStateId stateId)
    {
        if (transition == EnemyTransition.NullTransition)
        {
            Debug.Log("NullTransition is invalid!");
            return;
        }
        if (stateId == EnemyStateId.NullState)
        {
            Debug.Log("Null state id is invalid");
            return;
        }
        if (mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is already in the map!");
            return;
        }
        mMap.Add(transition, stateId);
    }
    public void DeleteTransition(EnemyTransition transition)
    {
        if (!mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is not in the map!");
            return;
        }
        mMap.Remove(transition);
    }
    //查询转换条件对应的下一个状态值
    public EnemyStateId GetOutputTransition(EnemyTransition transition)
    {
        if (!mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is not in the map!");
            return EnemyStateId.NullState;
        }
        return mMap[transition];
    }
    //进入状态前要做的事
    public virtual void DoBeforeEntering() { }
    //退出状态前要做的事
    public virtual void DoBeforeLeaving() { }
    //状态是否要切换
    public abstract void Reason(List<ICharacter> targets);
    //当前状态处理逻辑
    public abstract void Act(List<ICharacter> targets);

}
