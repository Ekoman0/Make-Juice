using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
public class Insterstetial : MonoBehaviour
{

    private string _adUnitId = "ca-app-pub-3138384441939461/3231619562";

    private static float Timer;
    private InterstitialAd _interstitialAd;
  

    bool showads;

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    /// 
     
    
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

      

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    
                    return;
                }

                

                _interstitialAd = ad;
                RegisterEventHandlers(_interstitialAd);
            });
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
          
            _interstitialAd.Show();
        }
        else
        {
           
        }
    }
    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
 
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadInterstitialAd();
        };
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("RestartAds"))
        {
            PlayerPrefs.SetInt("RestartAds",0);
        }

    }
    public void Start()
    {

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        if (PlayerPrefs.GetInt("Ads") != 1)
        {

            LoadInterstitialAd();
            Timer = UnityEngine.Random.Range(180, 190);

            if (PlayerPrefs.GetInt("RestartAds") == 1)
            {
                ShowInterstitialAd();
                PlayerPrefs.SetInt("RestartAds", 0);
            }
        }
       

    }
    public void RestartButton()
    {
        PlayerPrefs.SetInt("RestartAds", 1);
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("Ads") != 1)
        {
            Timer -= Time.deltaTime;
           
            if (Timer < 0)
            {
                ShowInterstitialAd();
                Timer = UnityEngine.Random.Range(300f, 360f);
            }
        }
       
    }
}
