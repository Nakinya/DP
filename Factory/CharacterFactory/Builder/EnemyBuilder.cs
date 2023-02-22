using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyBuilder : ICharacterBuilder
{
    public EnemyBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int level) : base(character, type, weaponType, spawnPosition, level)
    {
    }

    public override void AddCharacterAttr()
    {
        //设置ICharacterAttr
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        ICharacterAttr attr = new ICharacterAttr(new EnemyAttrStrategy(), mLv, baseAttr);
        mPrefabName = baseAttr.prefabName;
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色游戏物体
        GameObject enemyGO = FactoryManager.assetsFactory.LoadEnemy(mPrefabName);
        enemyGO.transform.position = mSpawnPosition;
        mCharacter.CharacterObject = enemyGO;
    }

    public override void AddWeapon()
    {
        //添加武器
        IWeapon weapon = FactoryManager.weaponFactory.CreatWeapon(mWeaponType);
        mCharacter.Weapon = weapon;
    }

    public override ICharacter GetCharacter()
    {
        return mCharacter;
    }
    public override void AddToCharacterSystem()
    {
        GameFacade.Instance.AddEnemy(mCharacter as IEnemy);
    }
}
