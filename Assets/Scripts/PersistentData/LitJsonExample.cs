using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

class Hero
{
    public string name;
    public int age;
}

class Heros
{
    public Hero[] heroes;
}

public class LitJsonExample : MonoBehaviour
{
    
    void Start()
    {
        fun3();
    }   
    //第一种 创建 解析方法
    void fun1()
    {
        Hero hero = new Hero();
        hero.name = "蝙蝠侠";
        hero.age = 30;

        Hero hero2 = new Hero();
        hero2.name = "小丑";
        hero2.age = 26;

        Heros heros = new Heros();
        heros.heroes = new Hero[] { hero, hero2 };
        //创建
        string toJson = JsonMapper.ToJson(heros);
        Debug.Log(toJson );
        
        //解析
        Heros heros2 = JsonMapper.ToObject<Heros>(toJson);
        Debug.Log(heros2.heroes[0].name);

    }
    
    //第二种方法创建Json
    void fun2()
    {
        //{"name":"小丑", "power":20}
        //{"name":"\u5C0F\u4E11","power":20}
        JsonData jd = new JsonData();//{}
        jd["name"] = "小丑";
        jd["power"] = 20;
        Debug.Log(jd.ToJson());

        //{"heros":[{"name":"小丑", "power":20},{"name":"蝙蝠侠", "power":30}]}
        //{"heros":[{"name":"\u5C0F\u4E11","power":20},{"name":"\u8759\u8760\u4FA0","power":30}]}
        JsonData herosJd = new JsonData();//{}
        JsonData hero1jd = new JsonData();//{}
        JsonData hero2jd = new JsonData();//{}
        hero1jd["name"] = "小丑";
        hero1jd["power"] = 20;
        hero2jd["name"] = "蝙蝠侠";
        hero2jd["power"] = 30;
        JsonData heros = new JsonData();//[]
        heros.SetJsonType(JsonType.Array);
        heros.Add(hero1jd);
        heros.Add(hero2jd);
        herosJd["heros"] = heros;
        Debug.Log(herosJd.ToJson());
    }

    //第二种方法解析Json
    void fun3()
    {
        string jsonData =
            @"{""heros"":[{""name"":""\u5C0F\u4E11"",""power"":20},{""name"":""\u8759\u8760\u4FA0"",""power"":30}]}";
           
        JsonData herosJd = JsonMapper.ToObject(jsonData);
        JsonData heros = herosJd["heros"];
        foreach (JsonData item in heros)
        {
            Debug.Log(item["name"]);
            Debug.Log(item["power"]);
        }
        

    }
}
