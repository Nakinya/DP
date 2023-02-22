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
        //����ICharacterAttr
        ////Υ���˿���ԭ����������ֻ������ʿ������û����չ
        ////���Զ�ICharacterAttr���ù���ģʽ
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

        //����ICharacterAttr
        CharacterBaseAttr baseAttr = FactoryManager.attrFactory.GetCharacterBaseAttr(mType);
        ICharacterAttr attr = new ICharacterAttr(new SoldierAttrStrategy(), mLv, baseAttr);
        mPrefabName = baseAttr.prefabName;
        mCharacter.Attr = attr;
    }

    public override void AddGameObject()
    {
        //������ɫ��Ϸ����
        GameObject soldierGO = FactoryManager.assetsFactory.LoadSoldier(mPrefabName);
        soldierGO.transform.position = mSpawnPosition;
        mCharacter.CharacterObject = soldierGO;
    }

    public override void AddWeapon()
    {
        //�������
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
