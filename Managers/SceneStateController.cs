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

    public void SetState(ISceneState newState, bool loadScene = true)//�л�����
    {
        //���ǰ����״̬�����״̬
        if (mState != null)
        {
            mState.StateEnd();
        }
        mState = newState;
        //���س�����ʹ��sceneManagement
        //�������и����⣬�޷���֤stateStart����ִ��ʱ�����Ѿ�׼����
        //SceneManager.LoadScene(mState.GetSceneStateName());
        //mState.StateStart();

        //ʹ���첽���س���LoadSceneAsync
        //mLoadSceneAP = SceneManager.LoadSceneAsync(newState.GetSceneStateName());
        //�и������ǿ�ʼ��Ϸʱ��Ĭ�ϼ��ؿ�ʼ����������setState�����󻹻����һ���첽���س����ķ��������һ��bool�����ж��Ƿ���س�����Ĭ��Ϊ����
        if (loadScene)
        {
            mLoadSceneAP = SceneManager.LoadSceneAsync(newState.GetSceneStateName());
        }
        else
        {
            mState.StateStart();//������ʼ��
            mLoadSceneAP = null;
        }
    }
    public void StateUpdate()
    {
        if (mLoadSceneAP != null && mLoadSceneAP.isDone == false)//�ڳ��������в�Ҫ����StateUpdate����
        {
            return;
        }

        if (mLoadSceneAP != null && mLoadSceneAP.isDone == true)
        {
            mState.StateStart();//���غó����󳡾���ʼ��
            mLoadSceneAP = null;//����Ϊnull�Ƿ�ֹ��������
        }

        if (mState != null)
            mState.StateUpdate();
    }
}
