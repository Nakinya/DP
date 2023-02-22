using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public interface IWeaponFactory
{
    public IWeapon CreatWeapon(WeaponType type);
}
