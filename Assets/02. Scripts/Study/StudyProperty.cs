using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [Header("헤더")]
    [SerializeField]
    private int number1 = 10; // 은닉성을 위배하지 않은 필드
    [Space(10)]
    [SerializeField]
    [Range(0, 10)]
    public int number2 = 20; // 은닉성을 위배한 필트

    [HideInInspector]
    private int number3;
    public int Number3 // 은닉성을 위배하지 않고 캡슐화한 프로퍼티
    {
        get // 접근자
        {
            return number3;
        }
        set // 설정자
        {
            number3 = value;
        }
    }

    private float hp = 100f;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (value < 0)
            {
                hp = 0f;
                Death();
            }
            else
            {
                hp = value;
            }
        }
    }

    public void Death()
    {
        Debug.Log("죽음");
    }
}
