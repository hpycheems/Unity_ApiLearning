using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExample : MonoBehaviour
{
    public Transform Green;
    public Transform Blue;
    public Transform Red;
    public Transform Yellow;
    
    // Start is called before the first frame update
    void Start()
    {
        //通过脚本设置渲染顺序
        Red.SetAsFirstSibling();
        Green.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
