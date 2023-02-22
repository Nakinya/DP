using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///武器基类，与角色类组成桥接模式
///</summary>

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket
}

public abstract class IWeapon
{
    //攻击力
    protected int mAttkPoint;
    //攻击范围
    protected float mAttkRange;
    //暴击伤害 由ICharacterAttr类给出
    //protected int mCriticalPoint;

    //对应游戏物体
    protected GameObject mGameObject;
    protected ICharacter mOwner;

    //特效和显示
    protected ParticleSystem mParticle;
    protected Light mLight;
    protected LineRenderer mLineRenderer;
    protected AudioSource mAudioSource;
    //特效持续时间
    protected float mEffectPlayTime = 0.5f;

    public int attkPoint { get { return mAttkPoint; } }

    public float attkRange { get { return mAttkRange; } }
    public ICharacter owner
    {
        set
        {
            mOwner = value;
        }
    }
    public GameObject gameObject { get { return mGameObject; } }
    
    public  IWeapon(int attkPoint, float attkRange, GameObject gameObject)
    {
        mAttkPoint = attkPoint;
        mAttkRange = attkRange;
        mGameObject = gameObject;

        //通过游戏物体的effect子物体获得特效
        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLineRenderer = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudioSource = effect.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(mEffectPlayTime > 0)
        {
            mEffectPlayTime -= Time.deltaTime;
            if (mEffectPlayTime <= 0)
                DisableEffects();
        }
    }
    //攻击 使用模板模式
    public void Fire(Vector3 targetPosition)
    {
        //1.播放枪口特效
        PlayMuzzleEffect(targetPosition);
        //2.播放子弹轨迹
        PlayBulletEffect(targetPosition);
        //3.播放射击音效
        PlaySoundEffect(targetPosition);
        //4.设置特效持续时间
        SetEffectPlayTime();
    }
    //播放枪口特效
    protected virtual void PlayMuzzleEffect(Vector3 targetPosition)
    {
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }
    //播放子弹轨迹
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    //播放音效
    protected abstract void PlaySoundEffect(Vector3 targetPosition);
    //子弹特效通过画线的方式实现
    //通用的子弹轨迹绘制方法
    protected void DoPlayBulletEffectGeneric(float lineWidth,Vector3 targetPosition)
    {
        mLineRenderer.enabled = true;
        mLineRenderer.startWidth = lineWidth;
        mLineRenderer.endWidth = lineWidth;
        mLineRenderer.SetPosition(0, mGameObject.transform.position);
        mLineRenderer.SetPosition(1,targetPosition);
    }
    //通用的子弹音效播放方法
    protected void DoPlaySoundEffectGeneric(string audioClipName, Vector3 targetPosition)
    {
        AudioClip audioClip = FactoryManager.assetsFactory.LoadAudioClip(audioClipName);//通过资源管理系统的接口获得
        mAudioSource.clip = audioClip;        
        mAudioSource.Play();
    }
    //设置特效持续时间
    protected abstract void SetEffectPlayTime();
    //禁用特效
    protected void DisableEffects()
    {
        mLineRenderer.enabled = false;
        mLight.enabled = false;
    }
}
