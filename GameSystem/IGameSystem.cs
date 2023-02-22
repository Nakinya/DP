using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///游戏系统基类，不使用接口是为了方便增加成员变量
///</summary>
public abstract class IGameSystem
{
    public virtual void Init() { }
    public virtual void Update() { }
    public virtual void End() { }
}
