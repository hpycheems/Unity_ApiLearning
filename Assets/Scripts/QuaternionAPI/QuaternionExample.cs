using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionExample : MonoBehaviour
{
    public Transform A, B, C;
    private Quaternion q1 = Quaternion.identity;
    public float speed = 10;
    Quaternion quaternion = Quaternion.identity;
    private Vector3 eulerAngles = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        Quaternion qt1 = Quaternion.identity;
        Quaternion qt2 = Quaternion.identity;
        qt1.eulerAngles = new Vector3(10, 20, 30);
        float f1 = Quaternion.Angle(qt1, qt2);
        float f2 = 0;
        Vector3 v1 = Vector3.zero;
        qt1.ToAngleAxis(out f2, out v1);

        Quaternion forward = Quaternion.LookRotation(new Vector3(0, 0, 0));
        A.rotation = forward;
        
        Debug.Log("f1:" + f1);
        Debug.Log("f2:" + f2);
        Debug.Log("q1的欧拉角：" + qt1.eulerAngles + "q1的rotation"+ qt1);
        Debug.Log("q2的欧拉角：" + qt2.eulerAngles + "q2的rotation"+ qt2);
    }

    // Update is called once per frame
    void Update()
    {
        //方式一
        //quaternion.eulerAngles = new Vector3(0, speed * Time.time, 0);
        //A.rotation = quaternion;
        //方式二
        //eulerAngles = new Vector3(0, speed * Time.time, 0);
        //B.eulerAngles = eulerAngles;
        
        //q1.SetFromToRotation(A.position, B.position);
        //C.rotation = q1;
        //Debug.DrawLine(Vector3.zero, A.position,Color.red);
        //Debug.DrawLine(Vector3.zero, B.position,Color.green);
        //Debug.DrawLine(C.position, C.position + new Vector3(0,1,0), Color.black);
        //Debug.DrawLine(C.position, C.TransformPoint(Vector3.up * 1.5f) , Color.yellow);
        
        //q1.SetLookRotation(A.position,B.position);
        //C.rotation = q1;
        
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 90 * Time.time, 0));
        C.rotation = rotation;
        
    }
}
