using UnityEngine;

public class StudyRandom : MonoBehaviour
{
    void OnEnable()
    {
        float ranNumber = Random.Range(0f, 100f);
        Debug.Log(ranNumber);
    }
}
