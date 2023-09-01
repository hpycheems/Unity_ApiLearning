using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class Person
{
    public string name;
    public int age;
}
[Serializable]
class Persons
{
    public Person[] persons;
}

public class JsonUtilityExample : MonoBehaviour
{
    void Start()
    {
        //创建
        Person person = new Person();
        person.name = "李逍遥";
        person.age = 18;
        //创建json
        Debug.Log( JsonUtility.ToJson(person));

        Person person2 = new Person();
        person2.name = "王小虎";
        person2.age = 9;

        Persons persons = new Persons();
        persons.persons = new Person[] { person, person2 };
        string jsonData = JsonUtility.ToJson(persons);
        Debug.Log(jsonData);
        
        //解析
        Persons personData = JsonUtility.FromJson<Persons>(jsonData);
        foreach (Person item in personData.persons)
        {
            Debug.Log(item.name);
        }
    }
}
