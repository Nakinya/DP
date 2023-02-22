using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class TrainSoldierCommand : ITrainCommand
{
    SoldierType mSoldierType;
    WeaponType mWeaponType;
    Vector3 mPosition;
    int mLevel;
    public TrainSoldierCommand(SoldierType type, WeaponType weaponType, Vector3 position, int level)
    {
        this.mSoldierType = type;
        this.mWeaponType = weaponType;
        this.mPosition = position;
        this.mLevel = level;
    }

    public override void Execute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.soldierFactory.CreatCharacter<SoldierRookie>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Sergeant:
                FactoryManager.soldierFactory.CreatCharacter<SoldierSergent>(mWeaponType, mPosition, mLevel);
                break;
            case SoldierType.Captain:
                FactoryManager.soldierFactory.CreatCharacter<SoldierCaptain>(mWeaponType, mPosition, mLevel);
                break;
            default:
                Debug.LogError("Invalid type of soldier: " + mSoldierType + " !");
                break;
        }
    }
}
