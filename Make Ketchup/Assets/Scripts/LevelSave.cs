using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSave : MonoBehaviour
{

    void Awake()
    {
        // Kaydedilen seviyeyi kontrol edin
        if (PlayerPrefs.HasKey("SavedLevel"))   
        {
            int savedLevel = PlayerPrefs.GetInt("SavedLevel");
            if (SceneManager.GetActiveScene().buildIndex != PlayerPrefs.GetInt("SavedLevel"))
            {
                SceneManager.LoadScene(savedLevel);
            }
        
        }
        else
        {
            PlayerPrefs.SetInt("SavedLevel",0);
            // Kaydedilen seviye yoksa, ilk seviyeyi yükleyin
            SceneManager.LoadScene(0); // 0 ana menü olduðunu varsayýyoruz
        }
    }

 
}
