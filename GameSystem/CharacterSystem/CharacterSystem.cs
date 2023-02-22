using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemies = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();

    public void AddEnemy(IEnemy enemy)
    {
        mEnemies.Add(enemy);
    }
    public void RemoveEnemy(IEnemy enemy)
    {
        mEnemies.Remove(enemy);
    }
    public void AddSoldier(ISoldier soldier)
    {
        mSoldiers.Add(soldier);
    }
    public void RemoveSoldier(ISoldier soldier)
    {
        mSoldiers.Remove(soldier);
    }
    public new void Init()
    {
       
    }
    private void RemoveKilledCharacters(List<ICharacter> characters)
    {
        ICharacter removeCharacter;
        for(int i = 0; i < characters.Count; i++)
        {
            if (characters[i].CanBeDestroyed)
            {
                removeCharacter = characters[i];
                i--;
                characters.Remove(removeCharacter);
                removeCharacter.Release();
            }
        }
    }
    public new void Update()
    {
        foreach(IEnemy enemy in mEnemies)
        {
            enemy.Update();
            enemy.UpdateFSM(mSoldiers); 
        }
        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.Update();
            soldier.UpdateFSM(mEnemies);
        }
        RemoveKilledCharacters(mEnemies);
        RemoveKilledCharacters(mSoldiers);
    }
    
    public void RunVisitor(ICharacterVisitor characterVisitor)
    {
        foreach (ICharacter soldier in mSoldiers)
        {
            soldier.RunVisitor(characterVisitor);
        }
        foreach (ICharacter enemy in mEnemies)
        {
            enemy.RunVisitor(characterVisitor);
        }
    }
}
