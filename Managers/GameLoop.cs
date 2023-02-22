using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class GameLoop : MonoBehaviour
{
    private SceneStateController mSceneStateController;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        mSceneStateController = new SceneStateController();//��ʼ��
        mSceneStateController.SetState(new GameStartState(mSceneStateController), false);
    }
    private void Update()
    {
        mSceneStateController.StateUpdate();
    }
}
