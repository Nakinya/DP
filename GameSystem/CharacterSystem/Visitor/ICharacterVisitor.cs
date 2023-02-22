using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///用于统计存活角色，只是为了实践访问者模式，从效率来看并不高效
///</summary>
public abstract class ICharacterVisitor
{
    public abstract void VisitEnemy(IEnemy enemy);
    public abstract void VisitSoldier(ISoldier soldier);
}
