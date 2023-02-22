using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class GamePlayState : ISceneState
{
    public GamePlayState(SceneStateController sceneController) : base("03_GamePlay", sceneController)
    {

    }
    //����Playģʽ��˵���ڴ�ģʽ����Ҫ��������ϵͳ�����ɫ����Դ����Ӫϵͳ��
    //���ȫ������Play״̬������Ļ������ͻ�ʮ��ӷ�ף������ڹ���
    //��Ϊ״̬��Ӧ�ù�ע״̬�����񣬶���Ӧ��ȥ��ע��ϵͳ������
    //ʹ�����ģʽ����װ�����ṩ�ӿ���������ϵͳ���Ӷ���״̬��רע��״̬������
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver())//��Ϸ����
        {
            //�л������˵�
            mSceneController.SetState(new GameMenuState(mSceneController));
        }
        else
        {
            GameFacade.Instance.Update();
        }
    }
    public override void StateEnd()
    {
        GameFacade.Instance.End();
    }
}
