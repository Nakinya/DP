using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class ResourceAssetFactory : IAssetsFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";
    public AudioClip LoadAudioClip(string name)
    {
        //对于Sprite和AudioClip要用Resource,Load带type的重载方法
        //return LoadAsset(AudioPath + name) as AudioClip;
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public Sprite LoadSprite(string name)
    { 
        //对于Sprite和AudioClip要用Resource,Load带type的重载方法
        //return LoadAsset(SpritePath + name) as Sprite;
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    private GameObject InstantiateGameObject(string path)
    {
        Object obj = Resources.Load(path);
        if (obj == null)
        {
            Debug.LogError("Load " + path + " failed!");
            return null;
        }
        return GameObject.Instantiate(obj) as GameObject;
    }
    //private Object LoadAsset(string path)
    //{
    //    Object obj = Resources.Load(path);
    //    if (obj == null)
    //    {
    //        Debug.LogError("Load " + path + " failed!");
    //        return null;
    //    }
    //    return obj;
    //}
}
