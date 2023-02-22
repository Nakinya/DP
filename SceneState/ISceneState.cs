using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///场景状态类基类
///</summary>
public abstract class ISceneState
{
    protected SceneStateController mSceneController;
    protected string mSceneName;

    public ISceneState(string sceneName,SceneStateController sceneStateController)//构造函数中保留一个场景名和场景控制类的引用
    {
        mSceneName = sceneName;
        mSceneController = sceneStateController;
    }
    public string GetSceneStateName()
    {
        return mSceneName;
    }
    public virtual void StateStart()
    {

    }
    public virtual void StateUpdate()
    {

    }
    public virtual void StateEnd()
    {

    }
}
