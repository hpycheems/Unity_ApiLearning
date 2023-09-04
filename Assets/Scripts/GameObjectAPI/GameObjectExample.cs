using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GameObjectExample : MonoBehaviour
{
    public Transform child;
    public Transform childchild;
    
    // Start is called before the first frame update
    void Start()
    {
        #region 变量

        Debug.Log(transform.gameObject.activeSelf);
        Debug.Log(child.gameObject.activeSelf);
        Debug.Log(childchild.gameObject.activeSelf);
        
        Debug.Log(transform.gameObject.activeInHierarchy);
        Debug.Log(child.gameObject.activeInHierarchy);
        Debug.Log(childchild.gameObject.activeInHierarchy);

        #endregion

        #region 构造函数

        GameObject obj = new GameObject();
        GameObject obj1 = new GameObject("MyObj");
        GameObject obj2 = new GameObject("MyObj2", typeof(Rigidbody),typeof( BoxCollider));

        #endregion
        Debug.Log("=================================");
        #region 公共函数

        Transform myTransform = transform.GetComponent<Transform>();
        Debug.Log(myTransform.name);
        
        Transform[] myTransforms = transform.GetComponents<Transform>();
        foreach (Transform item in myTransforms)
        {
            Debug.Log("Transforms :" + item.name);
        }

        Transform childrenTransform = transform.GetComponentInChildren<Transform>();
        Debug.Log(childrenTransform.name);

        Transform[] childrenTransforms = transform.GetComponentsInChildren<Transform>();
        foreach (Transform item in childrenTransforms)
        {
            Debug.Log("ChildrenTransform:" + item.name);
        }

        #endregion

        #region 静态方法

        GameObject.CreatePrimitive(PrimitiveType.Cube);

        #endregion
    }
}
