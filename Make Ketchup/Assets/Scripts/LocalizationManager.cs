using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class LocalizationManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SetDefaultLanguage());
    }

    IEnumerator SetDefaultLanguage()
    {
        // Localization Settings'in yüklenmesini bekleyin
        yield return LocalizationSettings.InitializationOperation;

        // Sistem dilini kontrol edin
        string systemLanguage = Application.systemLanguage.ToString();

        // Varsayýlan dili Ýngilizce olarak ayarlayýn
        Locale defaultLocale = LocalizationSettings.AvailableLocales.GetLocale("en");

        // Eðer sistem dili Türkçe ise, dil ayarýný Türkçe yapýn
        if (systemLanguage == SystemLanguage.Turkish.ToString())
        {
            defaultLocale = LocalizationSettings.AvailableLocales.GetLocale("tr");
        }

        // Ayarlanan dili kullanýn
        LocalizationSettings.SelectedLocale = defaultLocale;
    }
}