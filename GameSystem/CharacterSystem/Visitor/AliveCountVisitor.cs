using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class AliveCountVisitor : ICharacterVisitor
{
    public  int enemyCount { get; private set; }
    public  int soldierCount { get; private set; }
    public void Reset()
    {
        enemyCount = 0;
        soldierCount = 0;
    }
    public override void VisitEnemy(IEnemy enemy)
    {
        if (!enemy.IsKilled)
        {
            enemyCount++;
        }
    }

    public override void VisitSoldier(ISoldier soldier)
    {
        if (!soldier.IsKilled)
        {
            soldierCount++;
        }
    }
}
