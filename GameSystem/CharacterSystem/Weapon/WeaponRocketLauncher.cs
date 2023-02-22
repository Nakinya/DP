using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class WeaponRocketLauncher : IWeapon
{
    public WeaponRocketLauncher(int attkPoint, float attkRange, GameObject gameObject) : base(attkPoint, attkRange, gameObject)
    {
    }

    protected override void PlayBulletEffect(Vector3 targetPosition)
    {
        DoPlayBulletEffectGeneric(1.05f, targetPosition);
    }

    protected override void PlaySoundEffect(Vector3 targetPosition)
    {
        DoPlaySoundEffectGeneric("RocketShot", targetPosition);
    }

    protected override void SetEffectPlayTime()
    {
        mEffectPlayTime = 0.5f;
    }
}
