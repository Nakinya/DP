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
        mCampLevel.text = "��Ӫ�ȼ���" + camp.Level.ToString(); 
        mWeaponLevel.text = GetWeaponTypeString(camp.WeaponTypeLevel);

        Show();
    }
    public void ShowTrainingInfo()
    {
        if (mCamp == null)
            return;

        mTrainCount.text = "����ѵ����" + mCamp.GetTrainCount().ToString();
        mTrainTime.text = " ѵ��ʱ�䣺" + mCamp.GetTrainRemainingTime().ToString("0.00");
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
                weaponString = "��ǹ";
                break;
            case WeaponType.Rifle:
                weaponString = "��ǹ";
                break;
            case WeaponType.Rocket:
                weaponString = "�����";
                break;
            default:
                weaponString = "δ֪";
                break;
        }
        return "�����ȼ���" + weaponString;
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
            GameFacade.Instance.ShowMessage("��Ҫ������" + energy +"���������㣬�޷�ѵ���µ�ʿ����");
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
            GameFacade.Instance.ShowMessage("�����Ѵﵽ�������޷�����������");
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
            GameFacade.Instance.ShowMessage("��Ҫ������" + energy + "���������㣬�޷�����������");
        }
    }
    public void OnCampUpgradeButtonClick()
    {
        int energy = mCamp.CampUpgradeEnergyCost;
        if (energy < 0)
        {
            GameFacade.Instance.ShowMessage("��Ӫ�Ѵﵽ�������޷�����������");
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
            GameFacade.Instance.ShowMessage("��Ҫ������" + energy + "���������㣬�޷�������Ӫ��");
        }
    }
}
