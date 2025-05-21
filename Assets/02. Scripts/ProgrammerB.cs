using DevA;
using UnityEngine;

public class ProgrammerB : MonoBehaviour
{
    public ProgrammerA pA;

    void Start()
    {
        Debug.Log(pA.number2);
        pA.number2 = 20;
        Debug.Log(pA.number2);
    }
}
