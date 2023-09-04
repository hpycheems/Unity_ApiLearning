using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideFlagsExample : MonoBehaviour
{
    public GameObject obj;
    public Transform _transform;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        _transform = transform;

        obj.hideFlags = HideFlags.DontSave;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.hideFlags = HideFlags.DontSave;

        transform.hideFlags = HideFlags.DontSave;

        SceneManager.LoadScene("GameObjectDemo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
