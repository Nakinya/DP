using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///������ģʽʵ��ս����
///</summary>
public class SoldierCaptive : ISoldier
{
    //����ս���ĵ��˶���
    private IEnemy mEnemy;
    public SoldierCaptive(IEnemy enemy)
    {
        mEnemy = enemy;
        ICharacterAttr attr = new SoldierAttr(enemy.Attr.AttrStrategy, 1, enemy.Attr.BaseAttr);

        this.Attr = attr;
        this.CharacterObject = mEnemy.GameObj;
        this.Weapon = mEnemy.Weapon;
    }
    protected override void PlayEffect()
    {
        mEnemy.PlayEffect();
    }

    protected override void PlaySound()
    {
        //Do nothing
    }
}
