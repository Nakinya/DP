using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����״̬�����
///</summary>
public abstract class ISceneState
{
    protected SceneStateController mSceneController;
    protected string mSceneName;

    public ISceneState(string sceneName,SceneStateController sceneStateController)//���캯���б���һ���������ͳ��������������
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
