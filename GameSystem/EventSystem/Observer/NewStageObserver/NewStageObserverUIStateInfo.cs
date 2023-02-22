using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class NewStageObserverUIStateInfo : IGameEventObserver
{
    private UIStateInfo mUIStateInfo;
    private NewStageSubject mNewStageSubject;
    public NewStageObserverUIStateInfo(UIStateInfo uIStateInfo)
    {
        mUIStateInfo = uIStateInfo;
    }
    public override void SetSubject(IGameEventSubject subject)
    {
        mNewStageSubject = subject as NewStageSubject;
    }

    public override void Update()
    {
        mUIStateInfo.UpdateStageCout(mNewStageSubject.StageCount);
    }
}
