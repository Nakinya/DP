using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///����ͳ�ƴ���ɫ��ֻ��Ϊ��ʵ��������ģʽ����Ч������������Ч
///</summary>
public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}
