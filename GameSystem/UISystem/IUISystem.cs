using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///UIϵͳ����
///</summary>
public abstract class IUISystem
{
    public GameObject mRootUI;
    public virtual void Init() { }
    public virtual void Update() { }
    public virtual void End() { }
    public void Show()
    {
        mRootUI.SetActive(true);
    }
    public void Hide()
    {
        mRootUI.SetActive(false);
    }
    public void Show(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void Hide(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
