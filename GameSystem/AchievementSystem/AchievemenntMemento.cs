using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///±¸ÍüÂ¼Ä£Ê½
///</summary>
public class AchievemenntMemento
{
    public int enemyKilledCount { get; set; }
    public int soldierKilledCount { get; set; }
    public int maxStageLevel { get; set; }
    public void SaveData()
    {
        PlayerPrefs.SetInt("EemyKilledCount", enemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", soldierKilledCount);
        PlayerPrefs.SetInt("MaxStageLevel", maxStageLevel);
    }
    public void LoadData()
    {
        enemyKilledCount = PlayerPrefs.GetInt("EemyKilledCount");
        soldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount");
        maxStageLevel = PlayerPrefs.GetInt("maxStageLevel");
    }
}
