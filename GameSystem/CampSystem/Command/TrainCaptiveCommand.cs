using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private Vector3 mPosition;
    private int mLevel;
    public TrainCaptiveCommand(EnemyType enemyType, WeaponType weaponType, Vector3 positionn, int level = 1)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mPosition = positionn;
        mLevel = level;
    }
    public override void Execute()
    {
        IEnemy enemy = null;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyElf>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Orge:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyOrge>(mWeaponType, mPosition) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.enemyFactory.CreatCharacter<EnemyTroll>(mWeaponType, mPosition) as IEnemy;
                break;
            default:
                Debug.LogError("Invalid enemy type: " + mEnemyType);
                return;
        }
        GameFacade.Instance.RemoveEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.AddSoldier(captive);
    }
}
