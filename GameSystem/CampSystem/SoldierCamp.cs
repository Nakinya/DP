using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierCamp : ICamp
{
    const int MAX_LV = 4;
    private int mLevel = 1;//±øÓªµÈ¼¶
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 rallyPosition, int level, WeaponType weaponLevel, float trainTime) 
        : base(gameObject, name, icon, soldierType, rallyPosition, trainTime)
    {
        mLevel = level;
        mWeaponType = weaponLevel;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }
    public override int Level { get { return mLevel; } }
    public override WeaponType WeaponTypeLevel { get { return mWeaponType; } }
    public override int CampUpgradeEnergyCost
    {
        get
        {
            if (mLevel + 1 >= MAX_LV)
                return -1;
            else
                return mCampUpgradeEnergy;
        }
    }
    public override int WeaponUpgradeEnergyCost
    {
        get
        {
            if(mWeaponType +1 > WeaponType.Rocket)
                return -1;
            else 
                return mWeaponUpgradeEnergy;
        }
    }
    public override int TrainUpgradeEnergyCost
    {
        get
        {
            return mTrainEnergy;
        }
    }
    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mRallyPosition, mLevel);
        mTrainCommands.Add(cmd);
    }
    public override void UpgradeCamp()
    {
        if (mLevel + 1 >= MAX_LV)
        {
            return;
        }
        mLevel++;
        UpdateEnergyCost();
    }
    public override void UpgradeWeapon()
    {
        if (mWeaponType + 1 > WeaponType.Rocket)
        {
            return; 
        }
        mWeaponType++;
        UpdateEnergyCost();
    }
    protected override void UpdateEnergyCost()
    {
        mCampUpgradeEnergy = mEnergyCostStrategy.GetCampUpgradeEnergyCost(mSoldierType, mLevel);
        mWeaponUpgradeEnergy = mEnergyCostStrategy.GetWeaponUpgradeEnergyCost(mWeaponType);
        mTrainEnergy = mEnergyCostStrategy.GetSoldierTrainEnergyCost(mSoldierType, mLevel);
    }
}
