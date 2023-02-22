using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class UIStateInfo : IUISystem
{
    private List<GameObject> mHearts = new List<GameObject>();
    private Text mSoldierCount;
    private Text mEnemyCount;
    private Text mStageCount;
    private Slider mEnergyBar;
    private Text mEnergyText;
    private GameObject mGameOverUI;
    private Button mReturnToMenuButton;
    private Text mMessage;

    private float mMsgTimer = 0f;
    private float mMsgMaxTime = 2;

    private AliveCountVisitor mAliveVisitor = new AliveCountVisitor();
    public override void Init()
    {
        base.Init();

        GameObject canvas = UIToolkit.GetCanvas();
        mRootUI = UnityToolkit.FindInChildren(canvas, "GameStateUI");

        GameObject heart1 = UnityToolkit.FindInChildren(mRootUI, "Heart1");
        GameObject heart2 = UnityToolkit.FindInChildren(mRootUI, "Heart2");
        GameObject heart3 = UnityToolkit.FindInChildren(mRootUI, "Heart3");
        mHearts.Add(heart1);
        mHearts.Add(heart2);
        mHearts.Add(heart3);

        mSoldierCount = UIToolkit.FindChild<Text>(mRootUI, "SoldierCount");
        mEnemyCount = UIToolkit.FindChild<Text>(mRootUI, "EnemyCount");
        mStageCount = UIToolkit.FindChild<Text>(mRootUI, "StageCount");
        mEnergyBar = UIToolkit.FindChild<Slider>(mRootUI, "EnergyBar");
        mEnergyText = UIToolkit.FindChild<Text>(mRootUI, "EnergyText");
        mMessage = UIToolkit.FindChild<Text>(mRootUI, "Message");
        mReturnToMenuButton = UIToolkit.FindChild<Button>(mRootUI, "ReturnToMenuButton");
        mGameOverUI = UnityToolkit.FindInChildren(mRootUI, "GameOver");
        mMessage.text = "";

        GameFacade.Instance.RegisterObserver(GameEventType.NewStage, new NewStageObserverUIStateInfo(this));
        Hide(mGameOverUI);
    }
    public override void Update()
    {
        base.Update();
        if (mMsgTimer > 0)
        {
            mMsgTimer -= Time.deltaTime;
            if (mMsgTimer <= 0)
            {
                mMessage.text = "";
            }
        }
        UpdateAliveCount();
    }
    public void ShowMessage(string msg)
    {
        mMessage.text = msg;
        mMsgTimer = mMsgMaxTime;
    }
    public void UpdateEnergyBar(int currentEnergy, int maxEnergy)
    {
        mEnergyBar.value = (float)currentEnergy / maxEnergy;
        mEnergyText.text = currentEnergy + "/" + maxEnergy;
    }
    public void UpdateAliveCount()
    {
        mAliveVisitor.Reset();
        GameFacade.Instance.RunVisitor(mAliveVisitor);
        mEnemyCount.text = "敌人数量：" + mAliveVisitor.enemyCount.ToString();
        mSoldierCount.text = "战士数量：" + mAliveVisitor.soldierCount.ToString();
    }
    public void UpdateStageCout(int level)
    {
        mStageCount.text ="当前关卡数：" + level.ToString();
    }
}
