using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class Banner : MonoBehaviour
{


    private string _adUnitId = "ca-app-pub-3138384441939461/2977635986";


    BannerView _bannerView;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Ads"))
        {
            PlayerPrefs.SetInt("Ads", 0);
        }
    }

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
      

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen
        _bannerView = new BannerView(_adUnitId, AdSize.IABBanner, AdPosition.Bottom);
    }
    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
       
        _bannerView.LoadAd(adRequest);
    }
    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
           
            _bannerView.Destroy();
            _bannerView = null;
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
            CreateBannerView();
            LoadAd();
        }
        
    }
}
