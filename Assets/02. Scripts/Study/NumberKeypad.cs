using UnityEngine;

public class NumberKeypad : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject doorLock;
    public string password; // 비밀번호 설정
    public string keyPadNumber; // 입력한 숫자 적용
    
    Animator animator;

    public void OnInputNumber(string numString)
    {
        keyPadNumber += numString;
    }

    public void OnCheckNumber()
    {
        if (keyPadNumber == password)
        {
            Debug.Log("문열림");
            doorAnim.SetTrigger("Door Open");
            doorLock.SetActive(false);
        }
        
        else
        {
            Debug.Log("비밀번호 오류");
        }
        
        keyPadNumber = "";
    }
    
}
