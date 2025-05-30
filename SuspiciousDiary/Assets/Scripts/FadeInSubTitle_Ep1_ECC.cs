using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSubTitle_Ep1_ECC : MonoBehaviour
{
    public float fadeDuration = 1f;
    private CanvasGroup canvasGroup;

    void OnEnable()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) return;

        canvasGroup.alpha = 0f; // 시작은 완전 투명
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1f; // 완전 불투명
    }
}
