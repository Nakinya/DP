using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///ʿ��״̬������
///</summary>
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr) : base(strategy, level, baseAttr)
    { 

    }
}
