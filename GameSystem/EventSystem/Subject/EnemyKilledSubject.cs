using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///统计击杀的敌人数量
///</summary>
public class EnemyKilledSubject : IGameEventSubject
{
    private int mEnemyKilledNum = 0;
    public int EnemyKilledNum
    {
        get { return mEnemyKilledNum; }
    }
    public override void Notify()
    {
        mEnemyKilledNum++;
        base.Notify();
    }
}
