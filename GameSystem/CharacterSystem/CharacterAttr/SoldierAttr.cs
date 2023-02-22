using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Ê¿±ø×´Ì¬ÊôĞÔÀà
///</summary>
public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr) : base(strategy, level, baseAttr)
    { 

    }
}
