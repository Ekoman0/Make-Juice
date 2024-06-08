using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeOutText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fadeDuration = 2f;

    IEnumerator Start()
    {
        // Metnin tamamen g�r�n�r oldu�undan emin olun
        textMeshPro.alpha = 1f;

        // Belirledi�imiz s�re boyunca alpha de�erini azaltarak metni yava��a g�r�nmez yap
        float timer = 0f;
        while (timer < fadeDuration)
        {
            // Zaman� art�r ve alpha de�erini ayarla
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            textMeshPro.alpha = alpha;

            // Bir sonraki frame'i bekle
            yield return null;
        }

        // Coroutine tamamland���nda metni tamamen g�r�nmez hale getir
        textMeshPro.alpha = 0f;
    }
}
