using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class Rewarded : MonoBehaviour
{

    private string _adUnitId = "ca-app-pub-3138384441939461/8292374554";

    private string _UpgradeAdUnitId= "ca-app-pub-3138384441939461/4762077673";

    private string _ChangeAdUnitId= "ca-app-pub-3138384441939461/8038390974";

    private string _AgainAdUnitId= "ca-app-pub-3138384441939461/6224468626";

    private string _RedAdUnitId= "ca-app-pub-3138384441939461/5093465764";


    private RewardedAd _rewardedAd;
    private RewardedAd _upgraderewardedAd;
    private RewardedAd _changerewardedAd;
    private RewardedAd _againrewardedAd;
    private RewardedAd _RedrewardedAd;

    public UpgradeFruit UpgradeF;
    public ChangeFruit ChangeF;
    public ShootFruit ShootF;
    public FinishFruit FinishF;
    public GameObject RedLine;

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    #region Shoot
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

       
        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                   
                    return;
                }

               

                _rewardedAd = ad;
                RegisterEventHandlers(_rewardedAd);
            });
    }

    public void ShowRewardedAd()
    {


        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                int a = PlayerPrefs.GetInt("Shoot");
                PlayerPrefs.SetInt("Shoot", a + 1);
                ShootF.NumberText.text = PlayerPrefs.GetInt("Shoot").ToString();
                if (PlayerPrefs.GetInt("Shoot") > 0)
                {
                    ShootF.WatchadsImage.gameObject.SetActive(false);
                    ShootF.NumberText.gameObject.SetActive(true);
                }
            });
        }

    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadRewardedAd();
        };
    }
    #endregion

    #region Upgrade
    public void LoadUpgradeRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_upgraderewardedAd != null)
        {
            _upgraderewardedAd.Destroy();
            _upgraderewardedAd = null;
        }

       

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_UpgradeAdUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                   
                    return;
                }

             

                _upgraderewardedAd = ad;
                UpgradeRegisterEventHandlers(_upgraderewardedAd);
            });
    }

    public void ShowUpgradeRewardedAd()
    {


        if (_upgraderewardedAd != null && _upgraderewardedAd.CanShowAd())
        {
            _upgraderewardedAd.Show((Reward reward) =>
            {
                int a = PlayerPrefs.GetInt("Upgrade");
                PlayerPrefs.SetInt("Upgrade", a + 1);
                UpgradeF.NumberText.text = PlayerPrefs.GetInt("Upgrade").ToString();
                if (PlayerPrefs.GetInt("Upgrade") > 0)
                {
                    UpgradeF.WatchadsImage.gameObject.SetActive(false);
                    UpgradeF.NumberText.gameObject.SetActive(true);
                }
            });
        }
  
    }

    private void UpgradeRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadUpgradeRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadUpgradeRewardedAd();
        };
    }
    #endregion

    #region Change
    public void LoadChangeRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_changerewardedAd != null)
        {
            _changerewardedAd.Destroy();
            _changerewardedAd = null;
        }

      

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_ChangeAdUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    
                    return;
                }

                

                _changerewardedAd = ad;
                ChangeRegisterEventHandlers(_changerewardedAd);
            });
    }

    public void ShowChangeRewardedAd()
    {


        if (_changerewardedAd != null && _changerewardedAd.CanShowAd())
        {
            _changerewardedAd.Show((Reward reward) =>
            {
                int a = PlayerPrefs.GetInt("Change");
                PlayerPrefs.SetInt("Change", a + 1);
                ChangeF.NumberText.text = PlayerPrefs.GetInt("Change").ToString();
                if (PlayerPrefs.GetInt("Change") > 0)
                {
                    ChangeF.WatchadsImage.gameObject.SetActive(false);
                    ChangeF.NumberText.gameObject.SetActive(true);
                }
            });
        }
 
    }

    private void ChangeRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
         LoadChangeRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadChangeRewardedAd();
        };
    }
    #endregion

    #region Again
    public void LoadAgainRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_againrewardedAd != null)
        {
            _againrewardedAd.Destroy();
            _againrewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_AgainAdUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _againrewardedAd = ad;
                AgainRegisterEventHandlers(_againrewardedAd);
            });
    }

    public void ShowAgainRewardedAd()
    {


        if (_againrewardedAd != null && _againrewardedAd.CanShowAd())
        {
            _againrewardedAd.Show((Reward reward) =>
            {
                FinishF.WatchAdsLevel();


            });
        }

    }

    private void AgainRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadAgainRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadAgainRewardedAd();
        };
    }
    #endregion

    #region Red
    public void LoadRedRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_RedrewardedAd != null)
        {
            _RedrewardedAd.Destroy();
            _RedrewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_RedAdUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _RedrewardedAd = ad;
                RedRegisterEventHandlers(_RedrewardedAd);
            });
    }

    public void ShowRedRewardedAd(GameObject RewardRedLine)
    {


        if (_RedrewardedAd != null && _RedrewardedAd.CanShowAd())
        {
            _RedrewardedAd.Show((Reward reward) =>
            {
              
                RedLine.transform.position = RewardRedLine.transform.position;

                RewardRedLine.gameObject.SetActive(false);


            });
        }

    }

    private void RedRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadRedRewardedAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            LoadRedRewardedAd();
        };
    }
    #endregion
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        LoadRewardedAd();

        LoadUpgradeRewardedAd();

        LoadChangeRewardedAd();

        LoadAgainRewardedAd();

        LoadRedRewardedAd();
    }
}
