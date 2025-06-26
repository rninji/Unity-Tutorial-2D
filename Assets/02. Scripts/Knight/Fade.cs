using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fadePanel;

    public void OnFade(float fadeTime, Color color, bool isFadeStart)
    {
        StartCoroutine(FadeRoutine(fadeTime, color, isFadeStart));
    }
    public IEnumerator FadeRoutine(float fadeTime, Color color, bool isFadeStart)
    {
        float percent = 0f;
        float timer = 0f; // 사용될 타이머

        while (percent < 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            float value = isFadeStart ? percent : 1-percent;
            fadePanel.color = new Color(color.r, color.g, color.b, value);
            yield return null;  
        }
    }
}
