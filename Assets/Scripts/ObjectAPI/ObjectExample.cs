using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectExample : MonoBehaviour
{
    public GameObject cubePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        int id = gameObject.GetInstanceID();
        Debug.Log(id);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Debug.Log(cube.GetInstanceID());
        
        Destroy(cube, 2f);
        
        DontDestroyOnLoad(gameObject);
        //SceneManager.LoadScene(0);

        FindObjectOfType<Light>().color = Color.red;

        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
