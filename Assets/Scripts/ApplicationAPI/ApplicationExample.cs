using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.dataPath);//E:/work/Unity_ApiLearning/Assets
        Debug.Log(Application.isEditor);
        Debug.Log(Application.isPlaying);
        //C:/Users/Administrator/AppData/LocalLow/DefaultCompany/UnityAPILeaning
        Debug.Log(Application.persistentDataPath);
        //E:/ work / Unity_ApiLearning / Assets / StreamingAssets
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(Application.temporaryCachePath);

        //让游戏以指定帧数去运行
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quie();
#endif
        }
    }
}
