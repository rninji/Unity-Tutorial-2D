using UnityEngine;

public class StudyClass
{
    public int number;

    public StudyClass(int number)
    {
        this.number = number;
    }
}

public struct Study_Struct
{
    public int number;

    public Study_Struct(int number)
    {
        this.number = number;
    }
}

public class Study_ClassStruct : MonoBehaviour
{
    void Start()
    {
        Debug.Log("클래스 -----------------------");
        StudyClass c1 = new StudyClass(10);
        StudyClass c2 = c1;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        c2.number = 20;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");
        
        Debug.Log("구조체 -----------------------");
        Study_Struct s1 = new Study_Struct(10);
        Study_Struct s2 = s1;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
        s2.number = 20;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }

}
