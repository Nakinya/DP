using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class AttrFactory : IAttrFactory
{
    private Dictionary<System.Type, CharacterBaseAttr> mCharacterBaseAttrDict;
   
    public AttrFactory()
    {
        InitCharacterBaseAttr();
    }

    public override CharacterBaseAttr GetCharacterBaseAttr(System.Type t)
    {
        if(mCharacterBaseAttrDict.ContainsKey(t))
            return mCharacterBaseAttrDict[t];

        Debug.LogError("Type: " + t + " dose not exist in dictionary!");
        return null;
    }

    public void InitCharacterBaseAttr()
    {
        mCharacterBaseAttrDict = new Dictionary<System.Type, CharacterBaseAttr>();
        mCharacterBaseAttrDict.Add(typeof(SoldierRookie),
            new CharacterBaseAttr("Rookie", 80, 3f, "RookieIcon", "Soldier2"));
        mCharacterBaseAttrDict.Add(typeof(SoldierSergent),
            new CharacterBaseAttr("Sergeant", 90, 3.5f, "SergeantIcon", "Soldier3"));
        mCharacterBaseAttrDict.Add(typeof(SoldierCaptain),
            new CharacterBaseAttr("Captain", 100, 4f, "CaptainIcon", "Soldier1"));
        mCharacterBaseAttrDict.Add(typeof(EnemyElf),
            new CharacterBaseAttr("Elf", 100, 3f, "ElfIcon", "Enemy1"));
        mCharacterBaseAttrDict.Add(typeof(EnemyOrge),
            new CharacterBaseAttr("Orge", 120, 4f, "OrgeIcon", "Enemy2"));
        mCharacterBaseAttrDict.Add(typeof(EnemyTroll),
            new CharacterBaseAttr("Troll", 200, 1.5f, "TrollIcon", "Enemy3"));
    }
}
