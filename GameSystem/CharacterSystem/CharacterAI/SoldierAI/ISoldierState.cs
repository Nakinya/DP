using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///ʿ��״̬��
///</summary>
//ʿ��״̬ת������
public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemyInSight,
    CanAttack
}
//սʿ״̬ö��
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
    //��ѯת��������Ӧ����һ��״ֵ̬
    public SoldierStateId GetOutputTransition(SoldierTransition transition)
    {
        if (!mMap.ContainsKey(transition))
        {
            Debug.Log("Transition: " + transition + " is not in the map!");
            return SoldierStateId.NullState;
        }
        return mMap[transition];
    }
    //����״̬ǰҪ������
    public virtual void DoBeforeEntering() { }
    //�˳�״̬ǰҪ������
    public virtual void DoBeforeLeaving() { }
    //״̬�Ƿ�Ҫ�л�
    public abstract void Reason(List<ICharacter> targets);
    //��ǰ״̬�����߼�
    public abstract void Act(List<ICharacter> targets);

}
