using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///角色状态属性基类
///</summary>
public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;
    //暴击率
    protected float mCriticalRate;

    protected int mCurrentHP;
    //等级，影响MaxHP和MaxSpeed
    protected int mLv;


    //根据等级修改属性加成
    //为了方便不同角色使用不同修改方式，使用策略模式方便策略的更换
    protected IAttrStrategy mAttrStrategy;
    public IAttrStrategy AttrStrategy { get { return mAttrStrategy; } }
    public CharacterBaseAttr BaseAttr { get { return mBaseAttr; } }
    public int CriticalPoint { get { return mAttrStrategy.GetCriticalPoints(mAttrStrategy.GetExtraCriticalRate(mLv)); } }
    public int CurrenHP { get { return mCurrentHP; } }
    public ICharacterAttr(IAttrStrategy strategy, int level, CharacterBaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mAttrStrategy = strategy;
        mLv = level;
        mCurrentHP = mBaseAttr.maxHP + mAttrStrategy.GetExtraHP(mLv);
        //mMoveSpeed += strategy.GetExtraSpeed(mLv);
    }

    public void TakeDamage(int damage)
    {
        mCurrentHP -= damage;
    }
}
