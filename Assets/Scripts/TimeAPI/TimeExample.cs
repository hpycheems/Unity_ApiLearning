using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExample : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log(Time.realtimeSinceStartup);
        Debug.Log(Time.time);
        Time.captureFramerate = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.captureFramerate);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);
        //Debug.Log("smooth:"+Time.smoothDeltaTime);
    }
}
