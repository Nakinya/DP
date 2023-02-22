using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///士兵属性具体策略
///</summary>
public class SoldierAttrStrategy : IAttrStrategy
{
    public int GetCriticalPoints(float criticalRate)
    {
        return (int)(Random.Range(0, criticalRate) * 100);
    }

    public float GetExtraCriticalRate(int Lv)
    {
        return (Lv - 1) * 0.1f;
    }

    public int GetExtraHP(int Lv)
    {
        return (Lv - 1) * 10;
    }

    public float GetExtraSpeed(int Lv)
    {
        return (Lv - 1) * 0.3f;
    }

}
