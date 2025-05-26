using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{
    public int[] arrayNumber = new int[5];
    public List<int> listNumber = new List<int>();

    public int number1 = 1;
    int number2 = 2;
    [SerializeField]
    private int number3 = 3;
    [SerializeField]
    int number4 = 4;
    public int number5 = 5;
    
    void Start()
    {
        // Array 출력
        Debug.Log($"Array의 첫번째 값 : {arrayNumber[0]}");
        Debug.Log($"Array의 두번째 값 : {arrayNumber[1]}");
        Debug.Log($"Array의 세번째 값 : {arrayNumber[2]}");
        Debug.Log($"Array의 네번째 값 : {arrayNumber[3]}");
        Debug.Log($"Array의 다섯번째 값 : {arrayNumber[4]}");
        
        // List 입력
        listNumber.Add(1);
        listNumber.Add(2);
        listNumber.Add(3);
        listNumber.Add(4);
        listNumber.Add(5);
        
        // List 출력
        Debug.Log($"현재 List에 있는 데이터 수 : {listNumber.Count}");
        Debug.Log($"List 첫번째 값 : {listNumber[0]}");
        
    }
}
