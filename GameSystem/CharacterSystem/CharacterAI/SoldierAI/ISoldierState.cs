using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///士兵状态类
///</summary>
//士兵状态转换条件
public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemyInSight,
    CanAttack
}
//战士状态枚举
public enum SoldierStateId
{
    NullState,
    Idle,
    Chase,
    Attack
}
public abstract class ISoldierState
{
    protected Dictionary<SoldierTransition,SoldierStateId> mMap = new Dictionary<SoldierTransition,SoldierStateId>();
    protected SoldierStateId mStateId;
    protected ICharacter mCharacter;
    protected SoldierFSMSystem mFSM; 
    public ISoldierState(SoldierFSMSystem soldierFSMSystem, ICharacter character)
    {
        mFSM = soldierFSMSystem;
        mCharacter = character;
    }
    public SoldierStateId stateId { get { return mStateId; } }

    public void AddTransition(SoldierTransition transition, SoldierStateId stateId)
    {
        if(transition == SoldierTransition.NullTransition)
        {
            Debug.Log("NullTransition is invalid!");
            return;
        }
        if(stateId == SoldierStateId.NullState)
        {
            Debug.Log("Null state id is invalid");
            return;
        }
        if(mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is already in the map!");
            return;
        }
        mMap.Add(transition, stateId);
    }
    public void DeleteTransition(SoldierTransition transition)
    {
        if (!mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is not in the map!");
            return ;
        }
        mMap.Remove(transition);
    }
    //查询转换条件对应的下一个状态值
    public SoldierStateId GetOutputTransition(SoldierTransition transition)
    {
        if (!mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is not in the map!");
            return SoldierStateId.NullState;
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
