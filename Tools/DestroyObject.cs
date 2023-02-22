using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///
///</summary>
public class DestroyObject : MonoBehaviour
{
    private void Start()
    {
        //1秒后销毁物体
        Invoke("DestroyGameObject", 1f);
    }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
