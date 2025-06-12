using Cat;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SoundManager soundManager;
    
    public TextMeshProUGUI playTimeUI;
    public TextMeshProUGUI scoreUI;
    
    private static float timer;
    public static int score;

    public static bool isPlay;

    void Start()
    {
        soundManager.SetBGMSound("Intro");
    }

    void Update()
    {
        if (!isPlay) return;
        
        timer += Time.deltaTime;

        playTimeUI.text = $"Play Time : {timer:f1}s";
        scoreUI.text = $"X {score}";
    }

    public static void ResetPlayUI()
    {
        timer = 0f;
        score = 0;
    }
}
