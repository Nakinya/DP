using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(ICharacter character, Type type, WeaponType weaponType, Vector3 spawnPosition, int level) : base(character, type, weaponType, spawnPosition, level)
    {
    }

    public override void AddCharacterAttr()
    {
        //设置ICharacterAttr
        ////违反了开闭原则，由于这里只有三种士兵所以没有扩展
        ////可以对ICharacterAttr运用工厂模式
        //string name = "Invalid name";
        //int maxHP = 0;
        //float moveSpeed = -1f;
        //string iconSprite = "";
        //if (mType == typeof(SoldierRookie))
        //{
        //    name = "Rookie";
        //    maxHP = 80;
        //    moveSpeed = 3.0f;
        //    iconSprite = "RookieIcon";
        //    mPrefabName = "Soldier2";
        //}
        //else if (mType == typeof(SoldierCaptain))
        //{
        //    name = "Captain";
        //    maxHP = 100;
        //    moveSpeed = 4.0f;
        //    iconSprite = "CaptainIcon";
        //    mPrefabName = "Soldier1";
        //}
        //else if (mType == typeof(SoldierSergent))
        //{
        //    name = "Sergeant";
        //    maxHP = 90;
        //    moveSpeed = 3.5f;
        //    iconSprite = "SergeantIcon";
        //    mPrefabName = "Soldier3";
        //}
        //else
        //{
        //    Debug.LogError("type: " + mType + " is not surpported!");
        //}

        //设置ICharacterAttr
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        ICharacterAttr attr = new ICharacterAttr(new SoldierAttrStrategy(), mLv, baseAttr);
        mPrefabName = baseAttr.prefabName;
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        //创建角色游戏物体
        GameObject soldierGO = FactoryManager.assetsFactory.LoadSoldier(mPrefabName);
        soldierGO.transform.position = mSpawnPosition;
        mCharacter.CharacterObject = soldierGO;
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
        GameFacade.Instance.AddSoldier(mCharacter as ISoldier);
    }
}
