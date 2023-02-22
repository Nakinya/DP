using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class EnergySystem : IGameSystem
{
    private const float MAX_ENERGY = 100;
    private float mCurrentEnergy = MAX_ENERGY;
    private float mRecoverSpeed = 3f;
    public override void Init()
    {
        base.Init();
    }
    public override void Update()
    {
        base.Update();
        if (mCurrentEnergy >= MAX_ENERGY)
        {
            mCurrentEnergy = MAX_ENERGY;
            GameFacade.Instance.UpdateEnergyBar((int)mCurrentEnergy, (int)MAX_ENERGY);
            return;
        }
        mCurrentEnergy += mRecoverSpeed * Time.deltaTime;
        GameFacade.Instance.UpdateEnergyBar((int)mCurrentEnergy, (int)MAX_ENERGY);
    }
    public bool ConsumeEnergy(int energy)
    {
        if (mCurrentEnergy >= energy)
        {
            mCurrentEnergy -= energy;
            return true;
        }
        return false;
    }
    public void RecycleEnergy(int energy)
    {
        mCurrentEnergy += energy;
        mCurrentEnergy = mCurrentEnergy < MAX_ENERGY ? mCurrentEnergy : MAX_ENERGY;
    }
}
