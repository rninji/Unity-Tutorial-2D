using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public enum SceneType { TOWN, ADVENTURE }

    public SceneType sceneType = SceneType.TOWN;
    
    public Fade fade;
    public GameObject portalEffect;
    public GameObject loadingImage;

    public Image progressBar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(PortalRoutine());
    }

    IEnumerator PortalRoutine()
    {
        // 포탈 이펙트
        portalEffect.SetActive(true);
        
        // 로딩 이미지 전환
        yield return StartCoroutine(fade.FadeRoutine(3f, Color.white, true));
        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.FadeRoutine(3f, Color.white, false));

        // 프로그레스 바 차오르기
        while (progressBar.fillAmount < 1f)
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }

        // 씬 전환
        if (sceneType == SceneType.TOWN)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(0);
    }
}
