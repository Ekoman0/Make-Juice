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
        // Localization Settings'in y�klenmesini bekleyin
        yield return LocalizationSettings.InitializationOperation;

        // Sistem dilini kontrol edin
        string systemLanguage = Application.systemLanguage.ToString();

        // Varsay�lan dili �ngilizce olarak ayarlay�n
        Locale defaultLocale = LocalizationSettings.AvailableLocales.GetLocale("en");

        // E�er sistem dili T�rk�e ise, dil ayar�n� T�rk�e yap�n
        if (systemLanguage == SystemLanguage.Turkish.ToString())
        {
            defaultLocale = LocalizationSettings.AvailableLocales.GetLocale("tr");
        }

        // Ayarlanan dili kullan�n
        LocalizationSettings.SelectedLocale = defaultLocale;
    }
}