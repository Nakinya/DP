using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

///<summary>
///角色基类
///</summary>
public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudioSource;
    protected IWeapon mWeapon;
    protected Animation mAnim;

    protected bool mIsKilled = false;
    protected bool mCanBeDestroyed = false;
    protected float mDestroyTimer = 2f;
    public bool CanBeDestroyed
    {
        get
        {
            return mCanBeDestroyed;
        }
    }
    public NavMeshAgent NavMeshAgent
    {
        get { return mNavAgent; }
    }
    public bool IsKilled { get { return mIsKilled; } }
    public IWeapon Weapon 
    {
        get { return mWeapon; }
        set
        { 
            mWeapon = value; 
            mWeapon.owner = this;
            //获得武器位置
            GameObject weaponPoint = UnityToolkit.FindInChildren(mGameObject, "weapon-point");
            UnityToolkit.AttachChild(weaponPoint, mWeapon.gameObject);
        } 
    }
    public GameObject GameObj { get { return mGameObject; } }
    public GameObject CharacterObject
    {
        set
        {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudioSource = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
    }
    public ICharacterAttr Attr { get { return mAttr; } set { mAttr = value; } }
    public float AttackRange { get { return mWeapon.attkRange; } }
    
    public void Attack(ICharacter target)
    {
        mGameObject.transform.LookAt(target.GetPosition());
        mWeapon.Fire(target.GetPosition());
        PlayAnim("attack");

        target.UnderAttack(mWeapon.attkPoint + mAttr.CriticalPoint);
    }
    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
    }
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }
    public void MoveTo(Vector3 destPosion)
    {
        mNavAgent.SetDestination(destPosion);
        PlayAnim("move");
    }
    public Vector3 GetPosition()
    {
        if (mGameObject != null)
        {
            return mGameObject.transform.position;
        }
        return Vector3.zero;
    }
    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0)
            {
                mCanBeDestroyed = true;
            }
        }
        mWeapon.Update();
    }
    public virtual void Killed()
    {
        mIsKilled = true;
        mNavAgent.isStopped = true;
    }
    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }
    protected void DoPlaySoundGeneric(string soundName)
    {
        AudioClip clip = FactoryManager.assetsFactory.LoadAudioClip(soundName); //获得资源
        mAudioSource.clip = clip;
    }
    protected void DoPlayEffectGeneric(string effectName)
    {
        //1.加载特效资源 
        GameObject effectGO = FactoryManager.assetsFactory.LoadEffect(effectName);
        effectGO.transform.position = mGameObject.transform.position;
        //2.控制特效销毁流程
        effectGO.AddComponent<DestroyObject>();//1秒后销毁特效物体

    }
    public abstract void RunVisitor(ICharacterVisitor chracterVisitor);
  
}
