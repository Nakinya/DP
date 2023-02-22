using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierCaptain : ISoldier
{
    protected override void PlayEffect()
    {
        DoPlayEffectGeneric("CaptainDeadEffect");
    }

    protected override void PlaySound()
    {
        DoPlaySoundGeneric("CaptainDeath");
    }
}
