using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class FactoryManager : MonoBehaviour
{
    private static IAssetsFactory mAssetsFactory;
    private static ICharacterFactory mSoldierFactory;
    private static ICharacterFactory mEnemyFactory;
    private static IWeaponFactory mWeaponFactory;
    private static IAttrFactory mAttrFactory;

    public static IAttrFactory attrFactory
    {
        get
        {
            if (mAttrFactory == null)
                mAttrFactory = new AttrFactory();
            return mAttrFactory;
        }
    }
    public static IAssetsFactory assetsFactory
    {
        get
        {
            if(mAssetsFactory == null)
                mAssetsFactory = new ResourceAssetFactory();
            return mAssetsFactory;
        }
    }
    public static ICharacterFactory soldierFactory
    {
        get
        {
            if (mSoldierFactory == null)
                mSoldierFactory = new SoldierFactory();
            return mSoldierFactory;
        }
    }
    public static ICharacterFactory enemyFactory
    {
        get
        {
            if (mEnemyFactory == null)
                mEnemyFactory = new EnemyFactory();
            return mEnemyFactory;
        }
    }
    public static IWeaponFactory weaponFactory
    {
        get
        {
            if (mWeaponFactory == null)
                mWeaponFactory = new WeaponFactory();
            return mWeaponFactory;
        }
    }
}
