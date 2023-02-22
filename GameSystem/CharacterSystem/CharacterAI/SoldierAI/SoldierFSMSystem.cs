using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///×´Ì¬¿ØÖÆÀà
///</summary>
public class SoldierFSMSystem
{
    private List<ISoldierState> mStates = new List<ISoldierState>();
    private ISoldierState mCurrentState;
    public ISoldierState currentState { get { return mCurrentState; } }

    public void AddState(params ISoldierState[] soldierStates)
    {
        foreach (ISoldierState soldierState in soldierStates)
        {
            AddState(soldierState);
        }
    }
    public void AddState(ISoldierState soldierState)
    {
        if(soldierState == null)
        {
            Debug.Log("Invalid null state");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(soldierState);
            mCurrentState = soldierState;
            return;
        }
        foreach(ISoldierState state in mStates)
        {
            if (soldierState.stateId == state.stateId)
            {
                Debug.Log("State is already in the list!");
                return;
            }
        }
        mStates.Add(soldierState);
    }
    public void DeleteState(SoldierStateId stateId)
    {
        if(stateId == SoldierStateId.NullState)
        {
            Debug.Log("Invalid null state id!");
            return;
        }
        foreach (ISoldierState state in mStates)
        {
            if (state.stateId == stateId)
            {
                mStates.Remove(state);
                return;
            }
        }
        Debug.Log("StateId: " + stateId + " is not found!");
    }
    public void PerformTransition(SoldierTransition transition)
    {
        if (transition == SoldierTransition.NullTransition)
        {
            Debug.Log("Transition is null!");
            return;
        }
        SoldierStateId nextStateId = mCurrentState.GetOutputTransition(transition);
        if(nextStateId == SoldierStateId.NullState)
        {
            Debug.Log("Transition: " + transition + " does not have a valid state!");
            return;
        }
        foreach (ISoldierState state in mStates)
        {
            if (nextStateId == state.stateId)
            {
                state.DoBeforeLeaving();
                mCurrentState = state;
                state.DoBeforeEntering();
                return;
            }
        }
    }

}
