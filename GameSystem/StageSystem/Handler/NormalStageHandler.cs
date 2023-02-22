using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class NormalStageHandler : IStageHandler
{
    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    //当前关卡最多生成的敌人数量
    private int mEnemyCount;
    private Vector3 mSpawnPosition;

    private float mSpanwInterval = 1f;
    private float mSpawnTimer = 0f;
    private int mEnemySpawned = 0;
    public NormalStageHandler(StageSystem stageSystem, int level, int enemyKilledForStage, EnemyType enemyType, WeaponType weaponType, int enemyCount, Vector3 spawnPosition)
        : base(stageSystem, level, enemyKilledForStage)
    {
        mEnemyType = enemyType;
        mWeaponType = weaponType;
        mEnemyCount = enemyCount;
        mSpawnPosition = spawnPosition;
    }
    protected override void UpdateStage()
    {
        base.UpdateStage();

        if (mEnemySpawned < mEnemyCount)
        {
            mSpawnTimer += Time.deltaTime;
            if (mSpawnTimer >= mSpanwInterval)
            {
                SpawnEnemy();
                mEnemySpawned++;
                mSpawnTimer = 0f;
            }
        }
    }
    private void SpawnEnemy()
    {
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.enemyFactory.CreatCharacter<EnemyElf>(mWeaponType, mSpawnPosition);
                break;
            case EnemyType.Orge:
                FactoryManager.enemyFactory.CreatCharacter<EnemyOrge>(mWeaponType, mSpawnPosition);
                break;
            case EnemyType.Troll:
                FactoryManager.enemyFactory.CreatCharacter<EnemyTroll>(mWeaponType, mSpawnPosition);
                break;
            default:
                Debug.LogError("Invalid enemy type: " + mEnemyType);
                break;
        }
    }
}
