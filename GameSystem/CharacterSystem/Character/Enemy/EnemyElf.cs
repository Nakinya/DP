using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyElf : IEnemy
{
    public  override void PlayEffect()
    {
        DoPlayEffectGeneric("ElfHitEffect");
    }
}
