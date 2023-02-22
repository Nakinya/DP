using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��Ϸϵͳ���࣬��ʹ�ýӿ���Ϊ�˷������ӳ�Ա����
///</summary>
public abstract class IGameSystem
{
    public virtual void Init() { }
    public virtual void Update() { }
    public virtual void End() { }
}
