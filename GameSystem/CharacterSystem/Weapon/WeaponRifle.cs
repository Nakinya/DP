using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class WeaponRifle : IWeapon
{
    public WeaponRifle(int attkPoint, float attkRange, GameObject gameObject) : base(attkPoint, attkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffectGeneric(0.1f, targetPosition);
    }

    protected override void PlaySoundEffect(Vector3 targetPosition)
    {
        DoPlaySoundEffectGeneric("RifleShot", targetPosition);
    }

    protected override void SetEffectPlayTime()
    {
        mEffectPlayTime = 0.35f;
    }
}
