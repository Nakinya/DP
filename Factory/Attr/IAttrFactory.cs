using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public abstract class IAttrFactory
{
    public abstract CharacterBaseAttr GetCharacterBaseAttr(System.Type t);
}
