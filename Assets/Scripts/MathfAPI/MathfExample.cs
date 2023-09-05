using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float deg = 60f;
        float rad = Mathf.Deg2Rad * deg;
        Debug.Log(rad);

        Debug.Log(Mathf.Infinity);

        int num = 2;
        num =  Mathf.Clamp(num, -1, 1);
        Debug.Log(num);
        
        float num1 = -1;
        num1 = Mathf.Clamp01(num1);
        Debug.Log(num1);

        float f = Mathf.ClosestPowerOfTwo(16);
        Debug.Log(f);
        
        Debug.Log(Mathf.DeltaAngle(60, 300));
        
        Debug.Log(Mathf.InverseLerp(10,20, 15));
        
        Debug.Log(Mathf.Lerp(10,20, 0.5f));
        
        Debug.Log(Mathf.LerpAngle(0, 90, Time.time));
        
        Debug.Log(Mathf.Round(11.1f));
    }

    private float minAngle = 0;
    private float maxAngle = 90;

    private float currStrength = 10;
    private float maxStrength = 100;
    private float recoveryRate = 10;

    public Transform target;
    private float smoothTime = 0.3f;
    private float yVelocity = 0.0f;
    private void Update()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        transform.eulerAngles = new Vector3(0, angle, 0);

        currStrength = Mathf.MoveTowards(currStrength, 
            maxStrength, recoveryRate * Time.deltaTime);
        
        //transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
        //transform.position = new Vector3(Mathf.Repeat(Time.time, 3), transform.position.y, transform.position.z);
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

       //Debug.Log( Mathf.SmoothStep(1, 10, Time.deltaTime * 10));
    }
    
}
