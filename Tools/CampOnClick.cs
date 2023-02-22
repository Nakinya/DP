using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class CampOnClick : MonoBehaviour
{
    private ICamp mCamp;
    public ICamp Camp { set { mCamp = value; } }
    private void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfo(mCamp);
    }
}
