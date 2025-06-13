using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    void Start()
    {
        Student student = new Student();
    }

    public void CreateID()
    {
        
    }
}

public class Student : Person
{
    public string name;
    public int age;
    public string schoolName;
    public int classNumber;
    
    public Student()
    {
        Debug.Log("Student 생성자 실행");
    }

    public void Walk()
    {
        
    }

    public void Run()
    {
        
    }

    public void Study()
    {
        
    }
}

public class Soldier
{
    public string name;
    public int age;
    public int soldierNumber;
    public void Walk()
    {
        
    }

    public void Run()
    {
        
    }

    public void GunShoot()
    {
        
    }
}

public class Person
{
    public string name;
    public int age;

    public Person()
    {
        Debug.Log("Person 생성자 실행");
    }
    public void Walk()
    {
        
    }

    public void Run()
    {
        
    }
}
