using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Xml;

public class ParseXml : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //加载文件
        TextAsset xmldata = Resources.Load<TextAsset>("xmlData");
        //创建xml文档
        XmlDocument xmlDocument = new XmlDocument();
        //辅助加载
        TextReader reader = new StreamReader(Application.dataPath + "/xmlData.xml");
        //加载文档资源
        xmlDocument.Load(reader);

        //获取文档中的 单个资源 
        XmlNode money = xmlDocument.SelectSingleNode("//Money");
        if (money != null)
        {
            Debug.Log(money.InnerText);
        }
        
        //获取文档中 的多个资源
        XmlNode content = xmlDocument.SelectSingleNode("//Content");
        foreach (XmlNode node in content.ChildNodes)
        {
            Debug.Log(node.InnerText);
        }

    }
}
