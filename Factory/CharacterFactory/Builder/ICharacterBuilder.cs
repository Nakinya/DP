using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class ICharacterBuilder
{
    protected ICharacter mCharacter;
    protected System.Type mType;
    protected WeaponType mWeaponType;
    protected Vector3 mSpawnPosition;
    protected int mLv;
    protected string mPrefabName;

    //正常情况下character的创建应该放在具体建造者里
    public ICharacterBuilder(ICharacter character, System.Type type, WeaponType weaponType, Vector3 spawnPosition, int level)
    {
        mCharacter = character;
        mType = type;
        mWeaponType = weaponType;
        mSpawnPosition = spawnPosition;
        mLv = level;
    }
    public abstract void AddCharacterAttr();
    public abstract void AddGameObject();
    public abstract void AddWeapon();
    public abstract ICharacter GetCharacter();
    public abstract void AddToCharacterSystem();

}
