using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformExample : MonoBehaviour
{
    public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.GetChild(0).name);
        
        Debug.Log(transform.localPosition);
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            Debug.Log(child.localPosition);
        }

        Debug.Log(transform.eulerAngles.x);
        Debug.Log(transform.eulerAngles.y);
        Debug.Log(transform.eulerAngles.z);

        Debug.Log(transform.forward);
        Debug.Log(transform.TransformDirection(Vector3.forward));
        Debug.Log(transform.right);
        Debug.Log(transform.TransformDirection(Vector3.right));
        Debug.Log(transform.up);
        Debug.Log(transform.TransformDirection(Vector3.up));
        
        Vector3 Direction = transform.position - pivot.position;
        Debug.Log(Direction);
        Direction.Normalize();
        Debug.Log(Direction);
        Quaternion tr = Quaternion.LookRotation(Direction);
        pivot.rotation = tr;
        
        Debug.Log(pivot.hasChanged);
        
        Debug.Log(transform.localToWorldMatrix);

        pivot.parent = transform;
        
        Debug.Log(transform.worldToLocalMatrix);

        Debug.Log("IsChild:" +pivot.IsChildOf(transform));
        
        transform.DetachChildren();

        Debug.Log( transform.InverseTransformDirection(new Vector3(0, 0, 10)));
        Debug.Log( transform.InverseTransformPoint(new Vector3(1, 0, 1)));
        
        transform.LookAt(pivot, Vector3.up);
        
        pivot.Rotate(new Vector3(45,45,45));
        
        
    }

    // Update is called once per frame
    void Update()
    {
        pivot.Rotate(Vector3.up, 30 * Time.time, Space.World);
        
        transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
    }
}
