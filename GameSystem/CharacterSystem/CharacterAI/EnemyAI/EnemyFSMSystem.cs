using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyFSMSystem
{
    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrentState;
    public IEnemyState currentState { get { return mCurrentState; } }

    public void AddState(params IEnemyState[] enemyStates)
    {
        foreach (IEnemyState enemyState in enemyStates)
        {
            AddState(enemyState);
        }
    }
    public void AddState(IEnemyState enemyState)
    {
        if (enemyState == null)
        { 
            Debug.Log("Invalid null state");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(enemyState);
            mCurrentState = enemyState;
            mCurrentState.DoBeforeEntering();
            return;
        }
        foreach (IEnemyState state in mStates)
        {
            if (enemyState.stateId == state.stateId)
            {
                Debug.Log("State is already in the list!");
                return;
            }
        }
        mStates.Add(enemyState);
    }
    public void DeleteState(EnemyStateId stateId)
    {
        if (stateId == EnemyStateId.NullState)
        {
            Debug.Log("Invalid null state id!");
            return;
        }
        foreach (IEnemyState state in mStates)
        {
            if (state.stateId == stateId)
            {
                mStates.Remove(state);
                return;
            }
        }
        Debug.Log("StateId: " + stateId + " is not found!");
    }
    public void PerformTransition(EnemyTransition transition)
    {
        if (transition == EnemyTransition.NullTransition)
        {
            Debug.Log("Transition is null!");
            return;
        }
        EnemyStateId nextStateId = mCurrentState.GetOutputTransition(transition);
        if (nextStateId == EnemyStateId.NullState)
        {
            Debug.Log("Transition: " + transition + " does not have a valid state!");
            return;
        }
        foreach (IEnemyState state in mStates)
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
