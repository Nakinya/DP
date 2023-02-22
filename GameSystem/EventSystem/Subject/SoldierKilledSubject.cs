using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class SoldierKilledSubject : IGameEventSubject
{
    private int mSoldierKilledNum = 0;
    public int EnemyKilledNum
    {
        get { return mSoldierKilledNum; }
    }
    public override void Notify()
    {
        mSoldierKilledNum++;
        base.Notify();
    }
}
