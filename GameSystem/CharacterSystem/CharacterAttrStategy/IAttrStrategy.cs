using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����ģʽ�ӿ�
///</summary>
public interface IAttrStrategy
{
    //���ݵȼ��޸�Hp���ٶȺͱ�����
    public int GetExtraHP(int Lv);
    public float GetExtraSpeed(int Lv);
    public float GetExtraCriticalRate(int Lv);
    public int GetCriticalPoints(float criticalRate);
}
