using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierRookie : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffectGeneric("RookieDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySoundGeneric("RookieDeath");
    }
}
