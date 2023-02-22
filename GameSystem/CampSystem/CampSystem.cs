using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();
    public new void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);
        InitCamp(EnemyType.Elf);
    }
    private void InitCamp(SoldierType type)
    {
        string campGameObjectName = "";
        string name = null;
        string icon = null;
        Vector3 rallyPosition = Vector3.zero;
        int level = 1;
        WeaponType weaponType = WeaponType.Gun;
        float trainTime = 1f;

        switch (type)
        {
            case SoldierType.Rookie:
                campGameObjectName = "SoldierCamp_Rookie";
                name = "新手士兵";
                icon = "RookieCamp";
                trainTime = 3f;
                break;
            case SoldierType.Sergeant:
                campGameObjectName = "SoldierCamp_Sergeant";
                name = "中士士兵";
                icon = "SergeantCamp";
                trainTime = 4f;
                break; 
            case SoldierType.Captain:
                campGameObjectName = "SoldierCamp_Captain";
                name = "长官士兵";
                icon = "CaptainCamp";
                trainTime = 5f;
                break;
            default:
                Debug.LogError("Cannot find soldier type: " + type + ", the camp can not be created!");
                break;
        }
        GameObject campGameObject = GameObject.Find(campGameObjectName);
        rallyPosition = UnityToolkit.FindInChildren(campGameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(campGameObject, name, icon, type, rallyPosition, level, weaponType, trainTime);
        campGameObject.AddComponent<CampOnClick>().Camp = camp;
        mSoldierCamps.Add(type, camp);
    }
    private void InitCamp(EnemyType enemyType)
    {

        string campGameObjectName = "";
        string name = null;
        string icon = null;
        Vector3 rallyPosition = Vector3.zero;
        float trainTime = 1f;

        switch (enemyType)
        {
            case EnemyType.Elf:
                campGameObjectName = "SoldierCamp_CaptiveElf";
                name = "战俘ELF兵营";
                icon = "CaptiveCamp";
                trainTime = 3f;
                break;
            default:
                Debug.LogError("Cannot find enemy type: " + enemyType + ", the captive camp can not be created!");
                break;
        }
        GameObject campGameObject = GameObject.Find(campGameObjectName);
        rallyPosition = UnityToolkit.FindInChildren(campGameObject, "TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(campGameObject, name, icon, enemyType, rallyPosition, trainTime);
        campGameObject.AddComponent<CampOnClick>().Camp = camp;
        mCaptiveCamps.Add(enemyType, camp);
    }
    public new void Update()
    {
        foreach(SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }
        foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }
    }
    public new void End()
    {

    }
}
