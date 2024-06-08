using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{

    public AudioListener listener;

    public Sprite On;
    public Sprite off;
    public Image SoundImage;
    int on;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            on = PlayerPrefs.GetInt("Sound");
            if (on == 0)
            {
                SoundImage.sprite = On;
                //listener.enabled = true;
                AudioListener.pause = false;

            }
            else if (on == 1)
            {
                SoundImage.sprite = off;
                //listener.enabled = false;
                AudioListener.pause = true;
            }
        }


    }
    public void OpenCloseSound()
    {
        if (on == 1)
        {
            SoundImage.sprite = On;
            //listener.enabled = true;
            AudioListener.pause = false;
            on = 0;
            PlayerPrefs.SetInt("Sound",on);
        }
        else
        {
            SoundImage.sprite = off;
            //listener.enabled = false;
            AudioListener.pause = true;
            on = 1;
            PlayerPrefs.SetInt("Sound", on);
        }
    }
}
