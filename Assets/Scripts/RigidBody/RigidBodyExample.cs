using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyExample : MonoBehaviour
{
    public Rigidbody A, B , C;
    // Start is called before the first frame update
    void Start()
    {
        A.collisionDetectionMode = CollisionDetectionMode.Discrete;//默认设置
        B.collisionDetectionMode = CollisionDetectionMode.Continuous;//防止被穿越

        //A.mass = 5;
        //B.mass = 5;
        //A.AddForce(Vector3.right * 50);
        //A.AddForce(Vector3.forward * 10);
        //B.AddForce(Vector3.forward * 10);
        //A.inertiaTensor = new Vector3(5, 15, 2);

        //A.velocity = Vector3.forward * 10;
        //B.velocity = Vector3.forward * 5;
        A.AddExplosionForce(5000, transform.position, 1f);
        B.AddForceAtPosition(Vector3.forward * 500, B.transform.position + Vector3.right * 0.4f);
        
        C.AddTorque(new Vector3(0,100,0));

        Debug.Log(A.ClosestPointOnBounds(transform.position));

        Debug.Log(A.GetPointVelocity(A.transform.position));
        Debug.Log(A.GetRelativePointVelocity(A.transform.position));
        
        C.MovePosition(Vector3.forward * 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
