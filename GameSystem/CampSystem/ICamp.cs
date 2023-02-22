using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class ICamp
{
    protected GameObject mGameObject;
    protected string mName;
    protected string mIconSprite;
    protected SoldierType mSoldierType;
    protected Vector3 mRallyPosition;//¼¯ºÏµã
    protected float mTrainTime;
    protected List<ITrainCommand> mTrainCommands;
    private float mTrainTimerCountDown;
    protected  IEnergyCostStrategy mEnergyCostStrategy;
    protected int mCampUpgradeEnergy;
    protected int mWeaponUpgradeEnergy;
    protected int mTrainEnergy;

    public string Name { get { return mName; } }
    public string IconSprite { get { return mIconSprite; } }
    public abstract int Level { get; }
    public abstract WeaponType WeaponTypeLevel { get; }
    public abstract int CampUpgradeEnergyCost { get; }
    public abstract int WeaponUpgradeEnergyCost { get; }
    public abstract int TrainUpgradeEnergyCost { get; }
    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 rallyPosition, float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIconSprite = icon;
        mSoldierType = soldierType;
        mRallyPosition = rallyPosition;
        mTrainTime = trainTime;
        mTrainTimerCountDown = mTrainTime;

        mTrainCommands = new List<ITrainCommand>();
    }
    public virtual void Update()
    {
        UpdateCommand();
    }
    private void UpdateCommand()
    {
        if (mTrainCommands.Count <= 0)
        {
            return;
        }
        mTrainTimerCountDown -= Time.deltaTime;
        if(mTrainTimerCountDown <= 0)
        {
            mTrainCommands[0].Execute();
            mTrainCommands.RemoveAt(0);
            mTrainTimerCountDown = mTrainTime;
        }
    }
    public abstract void Train();
    protected abstract void UpdateEnergyCost();
    public abstract void UpgradeCamp();
    public abstract void UpgradeWeapon();
    public void CancelTrainCommand()
    {
        if (mTrainCommands.Count > 0)
        {
            mTrainCommands.RemoveAt(mTrainCommands.Count - 1);
            if (mTrainCommands.Count == 0)
            {
                mTrainTimerCountDown = mTrainTime;
            }
        }
    }
    public int GetTrainCount()
    {
        return mTrainCommands.Count;
    }
    public float GetTrainRemainingTime()
    {
        return mTrainTimerCountDown;
    }
}
