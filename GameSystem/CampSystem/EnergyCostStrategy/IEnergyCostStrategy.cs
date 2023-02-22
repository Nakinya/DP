using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class IEnergyCostStrategy
{
    public abstract int GetCampUpgradeEnergyCost(SoldierType type, int level);

    public abstract int GetWeaponUpgradeEnergyCost(WeaponType weaponType);

    public abstract int GetSoldierTrainEnergyCost(SoldierType type, int level);
}
