using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = new Vector3(10, 2, 1);
        Vector3 v1 = v.normalized;
        Debug.Log(v1);

        Vector3 v2 = new Vector3(3, 4, 5);
        float f = v2.sqrMagnitude;
        Debug.Log(f);

        Vector3 v3 = new Vector3(10, 10, 10);
        v3.Scale(new Vector3(2,2,2));
        Debug.Log(v3);

        Vector3 vertical = new Vector3(0, 1, 0);
        Vector3 horizontal = new Vector3(1, 0, 0);
        Debug.Log( Vector3.Angle(vertical, horizontal));

        Vector3 min = new Vector3(1, 1, 1);
        Debug.Log( Vector3.ClampMagnitude(min, 1));

        Debug.Log( Vector3.Cross(horizontal, vertical));
        Debug.Log(Vector3.Dot(horizontal, vertical));
        Debug.Log( Vector3.Lerp(horizontal, vertical, 0.5f));

        Debug.Log( Vector3.MoveTowards(Vector3.zero, Vector3.one, 0.2f));

        Debug.Log(Vector3.Project(new Vector3(1, 1, 0), new Vector3(10, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
