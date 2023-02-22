using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class StageSystem : IGameSystem
{
    private int mLevel = 1;
    private List<Vector3> mSpawnPositions = new List<Vector3>();
    private NormalStageHandler mFirstHandler;
    private Vector3 mTargetPosition;
    private int mNumOfEnemyKilled = 0;
    public override void Init()
    {
        base.Init();
        InitSpawnPositionList();
        InitStageChain();
        GameFacade.Instance.RegisterObserver(GameEventType.EnmeyKilled, new EnemyKilledObserverStageSystem(this));
    }
    public override void Update()
    {
        base.Update();
        mFirstHandler.Handle(mLevel);
    }
    private void InitSpawnPositionList()
    {
        int i = 1;
        while (true)
        {
            GameObject positionGO = GameObject.Find("SpawnPosition" + i);
            if (positionGO != null)
            {
                mSpawnPositions.Add(positionGO.transform.position);
                positionGO.SetActive(false);
                i++;
            }
            else
            {
                break;
            }
        }
        GameObject targetGO = GameObject.Find("Base");
        mTargetPosition = targetGO.transform.position;
    }
    private Vector3 GetRandomSpawnPosition()
    {
        //tip:range参数为int时不覆盖最大值
        return mSpawnPositions[Random.Range(0, mSpawnPositions.Count)];
    }
    private void InitStageChain()
    {
        int level = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, level++, 3, EnemyType.Elf, WeaponType.Gun, 3, GetRandomSpawnPosition());
        NormalStageHandler handler2 = new NormalStageHandler(this, level++, 6, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomSpawnPosition());
        NormalStageHandler handler3 = new NormalStageHandler(this, level++, 9, EnemyType.Elf, WeaponType.Rocket, 3, GetRandomSpawnPosition());
        NormalStageHandler handler4 = new NormalStageHandler(this, level++, 14, EnemyType.Orge, WeaponType.Gun, 5, GetRandomSpawnPosition());
        NormalStageHandler handler5 = new NormalStageHandler(this, level++, 19, EnemyType.Orge, WeaponType.Rifle, 5, GetRandomSpawnPosition());
        NormalStageHandler handler6 = new NormalStageHandler(this, level++, 24, EnemyType.Orge, WeaponType.Rocket, 5, GetRandomSpawnPosition());
        NormalStageHandler handler7 = new NormalStageHandler(this, level++, 32, EnemyType.Troll, WeaponType.Gun, 8, GetRandomSpawnPosition());
        NormalStageHandler handler8 = new NormalStageHandler(this, level++, 40, EnemyType.Troll, WeaponType.Rifle, 8, GetRandomSpawnPosition());
        NormalStageHandler handler9 = new NormalStageHandler(this, level++, 48, EnemyType.Troll, WeaponType.Rocket, 8, GetRandomSpawnPosition());

        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);
        mFirstHandler = handler1;
    }
    //获得击杀的敌人数量
    public int NumOfEnemyKilled
    {
        get { return mNumOfEnemyKilled; }
        set { mNumOfEnemyKilled = value; }
    }
    public void EnterNextStage()
    {
        mLevel++;
        if(mLevel > 9)
            mLevel = 9;
        GameFacade.Instance.Notify(GameEventType.NewStage);
    }
    public Vector3 TargetPosition
    {
        get
        {
            return mTargetPosition;
        }
    }
}
