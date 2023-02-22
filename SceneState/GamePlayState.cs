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
    //对于Play模式来说，在此模式下需要管理多个子系统，如角色、资源、兵营系统等
    //如果全部放在Play状态类里面的话这个类就会十分臃肿，不便于管理
    //作为状态类应该关注状态的事务，而不应该去关注子系统的事务
    //使用外观模式，让装饰类提供接口来管理子系统，从而让状态类专注在状态管理上
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver())//游戏结束
        {
            //切换回主菜单
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
