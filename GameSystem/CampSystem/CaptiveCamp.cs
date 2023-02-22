using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;
    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType enemyType, Vector3 rallyPosition, float trainTime)
     : base(gameObject, name, icon, SoldierType.Captive, rallyPosition, trainTime)
    {
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        mEnemyType = enemyType;
        UpdateEnergyCost();
    }
    public override int Level { get { return 1; } }
    public override WeaponType WeaponTypeLevel { get { return mWeaponType; } }
    public override int CampUpgradeEnergyCost
    {
        get
        {
            return -1;
        }
    }
    public override int WeaponUpgradeEnergyCost
    {
        get
        {
            return -1;
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
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType, mRallyPosition);
        mTrainCommands.Add(cmd);
    }

    public override void UpgradeCamp()
    {
        return;
    }

    public override void UpgradeWeapon()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mTrainEnergy = mEnergyCostStrategy.GetSoldierTrainEnergyCost(SoldierType.Captive, 1);
    }
}
