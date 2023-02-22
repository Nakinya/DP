using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierEnergyCostStrategy : IEnergyCostStrategy
{
    public override int GetCampUpgradeEnergyCost(SoldierType type, int level)
    {
        int energy = 0;
        switch (type)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                Debug.LogError("Invalid type: " + type + " for camp upgrade energy cost computation!");
                break;
        }
        energy += (level - 1) * 2;
        return energy > 100 ? 100 : energy;
    }

    public override int GetSoldierTrainEnergyCost(SoldierType type, int level)
    {
        int energy = 0;
        switch (type)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            case SoldierType.Captive:
                energy = 10;
                break;
            default:
                Debug.LogError("Invalid type: " + type + " for soldier train energy cost computation!");
                break;
        }
        energy += (level - 1) * 2;
        return energy > 80 ? 80 : energy;
    }

    public override int GetWeaponUpgradeEnergyCost(WeaponType weaponType)
    {
        int energy = 0;
        switch (weaponType)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
            case WeaponType.Rocket:
                energy = -1;
                break;
            default :
                Debug.LogError("Invalid type: " + weaponType + " for weapon upgrade energy cost computation!");
                break;
        }
        return energy;
    }
}
