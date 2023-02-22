using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
///</summary>
public static class UIToolkit
{
    public static GameObject GetCanvas(string name = "UICanvas")
    {
        return GameObject.Find(name);
    }
    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject go = UnityToolkit.FindInChildren(parent, childName);
        return go.GetComponent<T>();
    }
}
