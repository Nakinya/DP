using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType type)
    {
        IWeapon weapon = null;
        GameObject weaponResourceObject;
        switch (type)
        {
            case WeaponType.Rifle:
                weaponResourceObject = FactoryManager.assetsFactory.LoadWeapon("WeaponRifle");
                weapon = new WeaponRifle(30, 8, weaponResourceObject);
                break;
            case WeaponType.Gun:
                weaponResourceObject = FactoryManager.assetsFactory.LoadWeapon("WeaponGun");
                weapon = new WeaponGun(20, 5, weaponResourceObject);
                break;
            case WeaponType.Rocket:
                weaponResourceObject = FactoryManager.assetsFactory.LoadWeapon("WeaponRocket");
                weapon = new WeaponRocketLauncher(45, 10, weaponResourceObject);
                break;
        }
        return weapon;
    }
}
