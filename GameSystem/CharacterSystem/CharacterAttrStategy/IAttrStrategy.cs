using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///策略模式接口
///</summary>
public interface IAttrStrategy
{
    //根据等级修改Hp、速度和暴击率
    public int GetExtraHP(int Lv);
    public float GetExtraSpeed(int Lv);
    public float GetExtraCriticalRate(int Lv);
    public int GetCriticalPoints(float criticalRate);
}
