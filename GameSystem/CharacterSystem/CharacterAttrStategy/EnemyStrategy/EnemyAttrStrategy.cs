using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///敌人具体属性策略
///</summary>
public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCriticalPoints(float criticalRate)
    {
        return (int)(Random.Range(0, criticalRate) * 130);
    }

    public float GetExtraCriticalRate(int Lv)
    {
        return (Lv - 1) * 0.1f;
    }

    public int GetExtraHP(int Lv)
    {
        return (Lv - 1) * 8;
    }

    public float GetExtraSpeed(int Lv)
    {
        return (Lv - 1) * 0.2f;
    }
}
