using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///既是外观模式类也是中介者模式中介者类
///</summary>
public class GameFacade
{
    private bool mIsGameOver;//用来判断在play状态类里面是否要切换状态
    private static GameFacade instance;
    //实现单例模式
    private GameFacade() { }
    public static GameFacade Instance
    {
        get
        {
            if(instance == null)
                instance = new GameFacade();
            return instance;
        }
    }
    public bool IsGameOver()
    {
        return mIsGameOver;
    }
    #region 中介者模式组件类
    private AchievementSystem mAchievementSystem;
    private CharacterSystem mCharacterSystem;
    private CampSystem mCampSystem;
    private EnergySystem mEnergySystem;
    private EventSystem mEventSystem;
    private StageSystem mStageSystem;
    
    private UICampInfo mUICampInfo;
    private UIGamePause mUIGamePause;
    private UISoldierInfo mUISoldierInfo;
    private UIStateInfo mUIStateInfo;
    #endregion

    public void Init()//类似Start
    {
        mCharacterSystem = new CharacterSystem();
        mCampSystem = new CampSystem();
        mEnergySystem = new EnergySystem();
        //Event子系统初始化在Stage子系统前，保证关卡系统调用RegisterObserver时所有主题都存在
        mEventSystem = new EventSystem();
        mStageSystem = new StageSystem();
        mAchievementSystem = new AchievementSystem();

        mUICampInfo = new UICampInfo();
        mUIGamePause = new UIGamePause();
        mUISoldierInfo = new UISoldierInfo();
        mUIStateInfo = new UIStateInfo();

        mCharacterSystem.Init();
        mCampSystem.Init();
        mEnergySystem.Init();
        mEventSystem.Init();
        mStageSystem.Init();
        mAchievementSystem.Init();

        mUICampInfo.Init();
        mUIGamePause.Init();
        mUISoldierInfo.Init();
        mUIStateInfo.Init();

        LoadMemento();
    }
    public void Update()//类似Update
    {
        mCharacterSystem.Update();
        mCampSystem.Update();
        mEnergySystem.Update();
        mEventSystem.Update();
        mStageSystem.Update();
        mAchievementSystem.Update();

        mUICampInfo.Update();
        mUIGamePause.Update();
        mUISoldierInfo.Update();
        mUIStateInfo.Update();
    }
    public void End()//场景结束释放资源
    {
        CreateMemento();

        mCharacterSystem.End();
        mCampSystem.End();
        mEnergySystem.End();
        mEventSystem.End();
        mStageSystem.End();
        mAchievementSystem.End();

        mUICampInfo.End();
        mUIGamePause.End();
        mUISoldierInfo.End();
        mUIStateInfo.End();

    }
    public Vector3 GetEnemyTargetPosition()
    {
        return mStageSystem.TargetPosition;
    }

    //通过中介者模式来调用兵营UI显示，实现CampOnClick和UI之间的解耦
    public void ShowCampInfo(ICamp camp)
    {
        mUICampInfo.ShowCampInfo(camp);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mCharacterSystem.AddSoldier(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mCharacterSystem.RemoveSoldier(soldier);
    }
    public void AddEnemy(IEnemy enemy)
    {
        mCharacterSystem.AddEnemy(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mCharacterSystem.RemoveEnemy(enemy);
    }
    public bool ConsumeEnergy(int energy)
    {
        return mEnergySystem.ConsumeEnergy(energy);
    }
    public void ShowMessage(string msg)
    {
        mUIStateInfo.ShowMessage(msg);
    }
    public void RecycleEnergy(int energy)
    {
        mEnergySystem.RecycleEnergy(energy);
    }
    public void UpdateEnergyBar(int currentEnergy, int maxEnergy)
    {
        mUIStateInfo.UpdateEnergyBar(currentEnergy, maxEnergy);
    }
    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mEventSystem.RegisterObserver(eventType, observer);
    }
    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer)
    {
        mEventSystem.RemoveObserver(eventType, observer);
    }
    public void Notify(GameEventType eventType)
    {
        mEventSystem.Notify(eventType);
    }
    private void LoadMemento()
    {
        AchievemenntMemento memento = new AchievemenntMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }
     private void CreateMemento()
    {
        AchievemenntMemento memento = new AchievemenntMemento();
        memento.SaveData();
    }
    public void RunVisitor(ICharacterVisitor characterVisitor)
    {
        mCharacterSystem.RunVisitor(characterVisitor);
    }
}
