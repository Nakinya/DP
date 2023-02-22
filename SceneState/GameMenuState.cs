using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class GameMenuState : ISceneState
{
    private Button mbtn_StartGame;
    public GameMenuState(SceneStateController sceneController) : base("02_GameMenu", sceneController)
    {

    }
    public override void StateStart()
    {
        mbtn_StartGame = GameObject.Find("btn_StartGame").GetComponent<Button>();
        mbtn_StartGame.onClick.AddListener(OnStartButtonClicked);
    }
    private void OnStartButtonClicked()
    {
        mSceneController.SetState(new GamePlayState(mSceneController)); 
    }
}
