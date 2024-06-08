using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFruit : MonoBehaviour
{

    public SpawnFruits SpawnFruits;

    public Rewarded RewardedAds;

    public TextMeshProUGUI NumberText;
    public Image WatchadsImage;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Change"))
        {
            PlayerPrefs.SetInt("Change", 1);
            WatchadsImage.gameObject.SetActive(false);
            NumberText.gameObject.SetActive(true);
            NumberText.text = PlayerPrefs.GetInt("Change").ToString();
        }
        else
        {
            if (PlayerPrefs.GetInt("Change") > 0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
                NumberText.text = PlayerPrefs.GetInt("Change").ToString();
            }
            else
            {
                WatchadsImage.gameObject.SetActive(true);
                NumberText.gameObject.SetActive(false);

            }
        }

    }
    public void ChangeFruitButton()
    {


        if (PlayerPrefs.GetInt("Change") > 0)
        {

            int a = PlayerPrefs.GetInt("Change");

            PlayerPrefs.SetInt("Change", a - 1);

            SpawnFruits.ChangeFruits();


            if (PlayerPrefs.GetInt("Change") <= 0)
            {
                WatchadsImage.gameObject.SetActive(true);
                NumberText.gameObject.SetActive(false);
            }

            NumberText.text = PlayerPrefs.GetInt("Change").ToString();
        }
        else
        {
            RewardedAds.ShowChangeRewardedAd();
            NumberText.text = PlayerPrefs.GetInt("Change").ToString();
            if (PlayerPrefs.GetInt("Change") > 0)
            {
                WatchadsImage.gameObject.SetActive(false);
                NumberText.gameObject.SetActive(true);
            }

        }
    }
}
