using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///�������࣬���ɫ������Ž�ģʽ
///</summary>

public enum WeaponType
{
    Gun,
    Rifle,
    Rocket
}

public abstract class IWeapon
{
    //������
    protected int mAttkPoint;
    //������Χ
    protected float mAttkRange;
    //�����˺� ��ICharacterAttr�����
    //protected int mCriticalPoint;

    //��Ӧ��Ϸ����
    protected GameObject mGameObject;
    protected ICharacter mOwner;

    //��Ч����ʾ
    protected ParticleSystem mParticle;
    protected Light mLight;
    protected LineRenderer mLineRenderer;
    protected AudioSource mAudioSource;
    //��Ч����ʱ��
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

        //ͨ����Ϸ�����effect����������Ч
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
    //���� ʹ��ģ��ģʽ
    public void Fire(Vector3 targetPosition)
    {
        //1.����ǹ����Ч
        PlayMuzzleEffect(targetPosition);
        //2.�����ӵ��켣
        PlayBulletEffect(targetPosition);
        //3.���������Ч
        PlaySoundEffect(targetPosition);
        //4.������Ч����ʱ��
        SetEffectPlayTime();
    }
    //����ǹ����Ч
    protected virtual void PlayMuzzleEffect(Vector3 targetPosition)
    {
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }
    //�����ӵ��켣
    protected abstract void PlayBulletEffect(Vector3 targetPosition);
    //������Ч
    protected abstract void PlaySoundEffect(Vector3 targetPosition);
    //�ӵ���Чͨ�����ߵķ�ʽʵ��
    //ͨ�õ��ӵ��켣���Ʒ���
    protected void DoPlayBulletEffectGeneric(float lineWidth,Vector3 targetPosition)
    {
        mLineRenderer.enabled = true;
        mLineRenderer.startWidth = lineWidth;
        mLineRenderer.endWidth = lineWidth;
        mLineRenderer.SetPosition(0, mGameObject.transform.position);
        mLineRenderer.SetPosition(1,targetPosition);
    }
    //ͨ�õ��ӵ���Ч���ŷ���
    protected void DoPlaySoundEffectGeneric(string audioClipName, Vector3 targetPosition)
    {
        AudioClip audioClip = FactoryManager.assetsFactory.LoadAudioClip(audioClipName);//ͨ����Դ����ϵͳ�Ľӿڻ��
        mAudioSource.clip = audioClip;        
        mAudioSource.Play();
    }
    //������Ч����ʱ��
    protected abstract void SetEffectPlayTime();
    //������Ч
    protected void DisableEffects()
    {
        mLineRenderer.enabled = false;
        mLight.enabled = false;
    }
}
