using UnityEditor;
using UnityEngine;

public class EditorExample
{
    [MenuItem("Tools/Test", false, 23)]
    public static void Test()
    {
        Debug.Log("Test");
    }

    [MenuItem("Tools/Test01",true, 23)]
    public static bool ValidateTest()
    {
        return true;
    }

    [MenuItem("CONTEXT/Transform/Test4")]
    public static void Test04()
    {
        Debug.Log("Test4");
    }
}
