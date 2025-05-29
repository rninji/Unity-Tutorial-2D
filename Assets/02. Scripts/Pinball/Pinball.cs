using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager;
    void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score += 10;
                break;
            case "Score30":
                score += 30;
                break;
            case "Score50":
                score += 50;
                break;
        }

        if (score != 0)
        {
            pinballManager.totalScore += score;
            Debug.Log($"{score}점 획득");
        }
        
        // if (other.gameObject.CompareTag("Score10"))
        // {
        //     pinballManager.totalScore += 10;
        //     Debug.Log("10");
        // }
        // if (other.gameObject.CompareTag("Score30"))
        // {
        //     pinballManager.totalScore += 30;
        //     Debug.Log("30");
        // }
        // if (other.gameObject.CompareTag("Score50"))
        // {
        //     pinballManager.totalScore += 50;
        //     Debug.Log("50");
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("Game Over");
            Debug.Log($"최종 점수 : {pinballManager.totalScore}");
        }
    }
}
