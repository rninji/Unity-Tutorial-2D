using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(FadeRoutine(fadeTime, color));
    }
    IEnumerator FadeRoutine(float fadeTime, Color color)
    {
        float percent = 0f;
        float timer = 0f; // 사용될 타이머
        
        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            
            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;  
        }
    }
}
