using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RandomExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Random.insideUnitCircle);
        Debug.Log(Random.insideUnitSphere);
        Debug.Log(Random.onUnitSphere);

        transform.rotation = Random.rotationUniform;
        
        Random.InitState(100);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Random.value);
    }
}
