using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class UISoldierInfo : IUISystem
{
    private Text mHPInfo;
    private Slider mHPBar;
    private Text mLevelInfo;
    private Text mSoldierName;
    private Image mSoldierIcon;
    private Text mAttackInfo;
    private Text mAttackRangeInfo;
    private Text mMoveSpeedInfo;
    public override void Init()
    {
        base.Init();

        GameObject canvas = UIToolkit.GetCanvas();
        mRootUI = UnityToolkit.FindInChildren(canvas, "SoldierInfoUI");

        mHPInfo = UIToolkit.FindChild<Text>(mRootUI, "HPInfo");
        mHPBar = UIToolkit.FindChild<Slider>(mRootUI, "HPBar");
        mLevelInfo = UIToolkit.FindChild<Text>(mRootUI, "LevelInfo");
        mSoldierName = UIToolkit.FindChild<Text>(mRootUI, "SoldierName");
        mSoldierIcon = UIToolkit.FindChild<Image>(mRootUI, "SoldierIcon");
        mAttackInfo = UIToolkit.FindChild<Text>(mRootUI, "AttackInfo");
        mAttackRangeInfo = UIToolkit.FindChild<Text>(mRootUI, "AttackRangeInfo");
        mMoveSpeedInfo = UIToolkit.FindChild<Text>(mRootUI, "MoveSpeedInfo");
        Hide();
    }
}
