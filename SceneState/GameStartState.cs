using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class GameStartState : ISceneState
{
    private Image mLogo;
    private float mFadeTime = 2f;
    private float mLogoShowMaxTime = 3f;//logo��ʾ��ͣ��3��
    private float mLogoShowTimer;
    private Color mFadeColor = new Color(1, 1, 1, 0);
    public GameStartState(SceneStateController sceneController) : base("01_GameStart", sceneController)
    {
        mLogo = GameObject.Find("Logo").GetComponent<Image>();
    }
    public override void StateStart()
    {
        mLogo.color = new Color(1, 1, 1, 0);
        mLogoShowTimer = 0f;
    }
    public override void StateUpdate()//logo���룬��ʵӦ��д���뵭��Э��
    {
        if (mLogo.color.a <= 1)
        {
            mFadeColor.a += Time.deltaTime / mFadeTime;
            mLogo.color = mFadeColor;
        }
        if (1 - mLogo.color.a < 0.01)
        {
            mFadeColor.a = 1;
            mLogo.color = mFadeColor;
            mLogoShowTimer += Time.deltaTime;
            mLogoShowTimer = Mathf.Clamp(mLogoShowTimer, 0f, mLogoShowMaxTime);
        }
        if (mLogoShowTimer >= mLogoShowMaxTime)
        {
            mSceneController.SetState(new GameMenuState(mSceneController));//�л����˵�����
        }

    }

}
