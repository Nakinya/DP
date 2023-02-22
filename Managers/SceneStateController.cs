using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>
///
///</summary>
public class SceneStateController
{
    ISceneState mState;
    AsyncOperation mLoadSceneAP;

    public void SetState(ISceneState newState, bool loadScene = true)//切换场景
    {
        //如果前面有状态则结束状态
        if (mState != null)
        {
            mState.StateEnd();
        }
        mState = newState;
        //加载场景，使用sceneManagement
        //这样做有个问题，无法保证stateStart方法执行时场景已经准备好
        //SceneManager.LoadScene(mState.GetSceneStateName());
        //mState.StateStart();

        //使用异步加载场景LoadSceneAsync
        //mLoadSceneAP = SceneManager.LoadSceneAsync(newState.GetSceneStateName());
        //有个问题是开始游戏时会默认加载开始场景，调用setState方法后还会调用一次异步加载场景的方法，添加一个bool类型判断是否加载场景，默认为加载
        if (loadScene)
        {
            mLoadSceneAP = SceneManager.LoadSceneAsync(newState.GetSceneStateName());
        }
        else
        {
            mState.StateStart();//场景初始化
            mLoadSceneAP = null;
        }
    }
    public void StateUpdate()
    {
        if (mLoadSceneAP != null && mLoadSceneAP.isDone == false)//在场景加载中不要调用StateUpdate方法
        {
            return;
        }

        if (mLoadSceneAP != null && mLoadSceneAP.isDone == true)
        {
            mState.StateStart();//加载好场景后场景初始化
            mLoadSceneAP = null;//设置为null是防止反复调用
        }

        if (mState != null)
            mState.StateUpdate();
    }
}
