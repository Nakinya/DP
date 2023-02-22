using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnemyOrge : IEnemy
{
    public  override void PlayEffect()
    {
        DoPlayEffectGeneric("OgreHitEffect");
    }
}
