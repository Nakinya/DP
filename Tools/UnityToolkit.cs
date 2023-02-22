using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Unity工具类
///</summary>
public class UnityToolkit
{
    public static GameObject FindInChildren(GameObject parent, string childName)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        bool found = false;
        Transform child = null;
        foreach (Transform t in children)
        {
            if (t.name == childName)
            {
                //找到多个同名物体
                if (found)
                {
                    Debug.LogWarning("The number of child object : " + childName + " are more than 1 under " + parent);
                }
                found = true;
                child = t;
            }
        }
        return child.gameObject;
    }
    public static void AttachChild(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localEulerAngles = Vector3.zero;
        child.transform.localScale = Vector3.one;
    }
}
