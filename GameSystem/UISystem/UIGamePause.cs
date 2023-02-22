using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class UIGamePause : IUISystem
{
    private Button mContinueButton;
    private Button mReturnToMenuButton;
    private Text mCurrentLevel;
    public override void Init()
    {
        base.Init();

        GameObject canvas = UIToolkit.GetCanvas();
        mRootUI = UnityToolkit.FindInChildren(canvas, "PauseUI");

        mContinueButton = UIToolkit.FindChild<Button>(mRootUI, "ContinueButton");
        mReturnToMenuButton = UIToolkit.FindChild<Button>(mRootUI, "ReturnToMenuButton");
        mCurrentLevel = UIToolkit.FindChild<Text>(mRootUI, "CurrentLevel");
        Hide();
    }
}
