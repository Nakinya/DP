using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����״̬������
///</summary>
public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr) : base(strategy, level, baseAttr)
    {
        
    }
}
