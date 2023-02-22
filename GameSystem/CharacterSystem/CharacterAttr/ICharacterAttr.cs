using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///��ɫ״̬���Ի���
///</summary>
public class ICharacterAttr
{
    protected CharacterBaseAttr mBaseAttr;
    //������
    protected float mCriticalRate;

    protected int mCurrentHP;
    //�ȼ���Ӱ��MaxHP��MaxSpeed
    protected int mLv;


    //���ݵȼ��޸����Լӳ�
    //Ϊ�˷��㲻ͬ��ɫʹ�ò�ͬ�޸ķ�ʽ��ʹ�ò���ģʽ������Եĸ���
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
