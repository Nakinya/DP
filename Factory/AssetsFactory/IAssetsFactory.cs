using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public interface IAssetsFactory
{
    GameObject LoadSoldier(string name);
    GameObject LoadEnemy(string name);
    GameObject LoadWeapon(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
}
