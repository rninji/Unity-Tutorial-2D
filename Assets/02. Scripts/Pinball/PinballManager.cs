using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;
    public int totalScore;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftBarRb.AddTorque(50f);
        }
        else
        {
            leftBarRb.AddTorque(-30f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightBarRb.AddTorque(-50f);
        }
        else
        {
            rightBarRb.AddTorque(30f);
        }
    }
}
