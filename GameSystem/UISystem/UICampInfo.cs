using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public class UICampInfo : IUISystem
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mUpgradeCampButton;
    private Button mUpgradeWeaponButton;
    private Button mTrainButton;
    private Button mCancelTrainButton;
    private Text mAliveCount;
    private Text mTrainCount;
    private Text mTrainTime;
    private ICamp mCamp;
    public override void Init()
    {
        base.Init();

        GameObject canvas = UIToolkit.GetCanvas();
        mRootUI = UnityToolkit.FindInChildren(canvas, "CampInfoUI");

        mCampIcon = UIToolkit.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UIToolkit.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UIToolkit.FindChild<Text>(mRootUI, "CampLevel");
        mWeaponLevel = UIToolkit.FindChild<Text>(mRootUI, "WeaponLevel");
        mUpgradeCampButton = UIToolkit.FindChild<Button>(mRootUI, "UpgradeCampButton");
        mUpgradeWeaponButton = UIToolkit.FindChild<Button>(mRootUI, "UpgradeWeaponButton");
        mTrainButton = UIToolkit.FindChild<Button>(mRootUI, "TrainButton");
        mCancelTrainButton = UIToolkit.FindChild<Button>(mRootUI, "CancelTrainButton");
        mAliveCount = UIToolkit.FindChild<Text>(mRootUI, "AliveCount");
        mTrainCount = UIToolkit.FindChild<Text>(mRootUI, "TrainCount");
        mTrainTime = UIToolkit.FindChild<Text>(mRootUI, "TrainTime");

        mTrainButton.onClick.AddListener(OnTrainButtonClick);
        mCancelTrainButton.onClick.AddListener(OnCancelTrainButtonClick);
        mUpgradeCampButton.onClick.AddListener(OnCampUpgradeButtonClick);
        mUpgradeWeaponButton.onClick.AddListener(OnWeaponUpgradeButtonClick);
        Hide();
    }
    public override void Update()
    {
        base.Update();
        ShowTrainingInfo();
    }
    public void ShowCampInfo(ICamp camp)
    {
        mCamp = camp;
        mCampIcon.sprite = FactoryManager.assetsFactory.LoadSprite(camp.IconSprite);
        mCampName.text = camp.Name;
        mCampLevel.text = "??????????" + camp.Level.ToString(); 
        mWeaponLevel.text = GetWeaponTypeString(camp.WeaponTypeLevel);

        Show();
    }
    public void ShowTrainingInfo()
    {
        if (mCamp == null)
            return;

        mTrainCount.text = "??????????" + mCamp.GetTrainCount().ToString();
        mTrainTime.text = " ??????????" + mCamp.GetTrainRemainingTime().ToString("0.00");
        if (mCamp.GetTrainCount() == 0)
        {
            mCancelTrainButton.interactable = false;
        }
        else
        {
            mCancelTrainButton.interactable = true;
        }
    }
    private string GetWeaponTypeString(WeaponType type)
    {
        string weaponString = "";
        switch (type)
        {
            case WeaponType.Gun:
                weaponString = "????";
                break;
            case WeaponType.Rifle:
                weaponString = "????";
                break;
            case WeaponType.Rocket:
                weaponString = "??????";
                break;
            default:
                weaponString = "????";
                break;
        }
        return "??????????" + weaponString;
    }
    public void OnTrainButtonClick()
    {
        int energy = mCamp.TrainUpgradeEnergyCost;
        if (GameFacade.Instance.ConsumeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            GameFacade.Instance.ShowMessage("??????????" + energy +"??????????????????????????????");
        }
    }
    public void OnCancelTrainButtonClick()
    {
        int energy = mCamp.TrainUpgradeEnergyCost;
        GameFacade.Instance.RecycleEnergy(energy);
        mCamp.CancelTrainCommand();
    }
    public void OnWeaponUpgradeButtonClick()
    {
        int energy = mCamp.WeaponUpgradeEnergyCost;
        if (energy < 0)
        {
            GameFacade.Instance.ShowMessage("??????????????????????????????");
            Debug.Log("Cannot upgrade weapon!");
            return;
        }
        if (GameFacade.Instance.ConsumeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }
        else
        {
            GameFacade.Instance.ShowMessage("??????????" + energy + "??????????????????????????");
        }
    }
    public void OnCampUpgradeButtonClick()
    {
        int energy = mCamp.CampUpgradeEnergyCost;
        if (energy < 0)
        {
            GameFacade.Instance.ShowMessage("??????????????????????????????");
            Debug.Log("Cannot upgrade camp!");
            return;
        }
        if (GameFacade.Instance.ConsumeEnergy(energy))
        {
            mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }
        else
        {
            GameFacade.Instance.ShowMessage("??????????" + energy + "??????????????????????????");
        }
    }
}
