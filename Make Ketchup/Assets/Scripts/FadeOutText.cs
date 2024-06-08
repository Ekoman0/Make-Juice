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
        // Metnin tamamen görünür olduðundan emin olun
        textMeshPro.alpha = 1f;

        // Belirlediðimiz süre boyunca alpha deðerini azaltarak metni yavaþça görünmez yap
        float timer = 0f;
        while (timer < fadeDuration)
        {
            // Zamaný artýr ve alpha deðerini ayarla
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            textMeshPro.alpha = alpha;

            // Bir sonraki frame'i bekle
            yield return null;
        }

        // Coroutine tamamlandýðýnda metni tamamen görünmez hale getir
        textMeshPro.alpha = 0f;
    }
}
