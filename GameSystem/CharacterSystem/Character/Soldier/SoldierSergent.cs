using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierSergent : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffectGeneric("SergeantDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySoundGeneric("SergeantDeath");
    }
}
