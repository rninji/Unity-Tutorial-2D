using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;
    public bool isFadeIn = false;

    void Start()
    {
        StartCoroutine(FadeRoutine(3f));
    }
    IEnumerator FadeRoutine(float fadeTime)
    {
        float percent = 0f;
        float timer = 0f; // 사용될 타이머
        float value = 0f;
        
        while (timer <= fadeTime)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            value = isFadeIn ? 1 - percent : percent;
            
            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, value);
            yield return null;  
        }
    }
}
