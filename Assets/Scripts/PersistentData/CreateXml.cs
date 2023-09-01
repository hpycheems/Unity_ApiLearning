using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class CreateXml : MonoBehaviour
{
    public int Money;
    public int Score;
    
    void Start()
    {
        string path = Application.dataPath + "/xmlData.xml";

        //创建XML文档
        XmlDocument xmlDocument = new XmlDocument();
        //创建头文档
        XmlDeclaration xmlDeclaration = 
            xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "");
        
        //创建根结点
        XmlElement root = xmlDocument.CreateElement("Save");
        //给根节点创建属性
        root.SetAttribute("Name", "SaveFile");

        XmlElement content = xmlDocument.CreateElement("Content");
        XmlElement xmlMoney = xmlDocument.CreateElement("Money");
        xmlMoney.InnerText = Money.ToString();
        XmlElement xmlScore = xmlDocument.CreateElement("Score");
        xmlScore.InnerText = Score.ToString();

        //给文档添加 头
        xmlDocument.AppendChild(xmlDeclaration);
        //给文档添加root结点
        xmlDocument.AppendChild(root);

        root.AppendChild(content);
        content.AppendChild(xmlMoney);
        content.AppendChild(xmlScore);
        
        xmlDocument.Save(path);
    }
}
