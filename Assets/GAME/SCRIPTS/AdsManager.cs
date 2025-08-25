using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : Singleton<AdsManager>
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    private RewardedAd rewardedAd;

    private AppOpenAd appOpenAd;

    float delayBanner = 1, delayInter = 1, DelayReward = 1, DelayAppOpen = 1;
    void Init()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            Debug.Log("AdMob Initialized");
            LoadBanner();
            LoadInterstitial();
            LoadRewardedAd();
            LoadAppOpenAd();
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Init();
    }

    #region Banner
    void InitBanner()
    {
        this.bannerView = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.Banner, AdPosition.Bottom);
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner loaded");
            bannerView.Show();
            delayBanner = 1;
        };
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner failed to load: " + error);
            Invoke(nameof(LoadBanner), delayBanner);
            delayBanner *= 2;
            
        };
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log("Banner ad paid: " + adValue.Value + " " + adValue.CurrencyCode + " " + adValue.Precision);
        };

        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner impression recorded");
        };

        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner ad clicked");
        };

        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner opened full screen content");
        };
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner closed full screen content");
        };


    }

    void LoadBanner()
    {
        if (this.bannerView == null)
        {
            this.InitBanner();
        }

        bannerView.LoadAd(new AdRequest());
    }

    public void HideBanner()
    {
        if (this.bannerView != null)
        {
            this.bannerView.Hide();
        }
    }

    #endregion

    #region Interstitial


    void LoadInterstitial()
    {
        // Create our request used to load the ad.
        var adRequest = new AdRequest();



        // Send the request to load the ad.
        InterstitialAd.Load("ca-app-pub-3940256099942544/1033173712", adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
               
               Invoke(nameof(LoadInterstitial), delayInter);
               delayInter *= 2;
                return;
            }

            delayInter = 1;
            this.interstitial = ad;

            ad.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log("Interstitial ad paid: " + adValue.Value + " " + adValue.CurrencyCode + " " + adValue.Precision);
            };
            ad.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Interstitial impression recorded");
            };
            ad.OnAdClicked += () =>
            {
                Debug.Log("Interstitial ad clicked");
            };
            ad.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Interstitial opened full screen content");
            };
            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Interstitial closed full screen content");
                this.interstitial = null;
                LoadInterstitial();
            };
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Debug.LogError("Interstitial failed to open full screen content: " + error);
            };

        });
    }

    public void ShowInterstitial()
    {
        if (this.interstitial != null && this.interstitial.CanShowAd())
        {
            this.interstitial.Show();

        }
        else
        {
            Debug.Log("Interstitial ad is not ready yet");
        }
    }
    #endregion

    #region Rewarded
    void LoadRewardedAd()
    {
        var adRequest = new AdRequest();
        RewardedAd.Load("ca-app-pub-3940256099942544/5224354917", adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null)
            {
                Invoke(nameof(LoadRewardedAd), DelayReward);
                DelayReward *= 2;
                return;
            }

            DelayReward = 1;
            this.rewardedAd = ad;
            // The ad was loaded.
            ad.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log("Rewarded ad paid: " + adValue.Value + " " + adValue.CurrencyCode + " " + adValue.Precision);
            };
            ad.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Rewarded impression recorded");
            };
            ad.OnAdClicked += () =>
            {
                Debug.Log("Rewarded ad clicked");
            };
            ad.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Rewarded opened full screen content");
            };
            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Rewarded closed full screen content");
                this.rewardedAd = null;
                LoadRewardedAd();

            };
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Debug.LogError("Rewarded failed to open full screen content: " + error);
            };
        });
    }

    public void ShowRewardedAd(Action getReward)
    {
        if (this.rewardedAd != null && this.rewardedAd.CanShowAd())
        {
            this.rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("User earned reward of " + reward.Amount + " " + reward.Type);
                getReward?.Invoke();
            });
        }
        else
        {
            Debug.Log("Rewarded ad is not ready yet");
        }
    }
    #endregion

    #region AppOpen
    void LoadAppOpenAd()
    {
        var adRequest = new AdRequest();
        AppOpenAd.Load("ca-app-pub-3940256099942544/9257395921", adRequest, (AppOpenAd ad, LoadAdError error) =>
       {
           if (error != null)
           {
               Invoke(nameof(LoadAppOpenAd), DelayAppOpen);
               DelayAppOpen *= 2;
               // The ad failed to load.
               return;
           }

           DelayAppOpen = 1;
           this.appOpenAd = ad;
           // The ad was loaded.
           ad.OnAdPaid += (AdValue adValue) =>
           {
               Debug.Log("AppOpen ad paid: " + adValue.Value + " " + adValue.CurrencyCode + " " + adValue.Precision);
           };
           ad.OnAdImpressionRecorded += () =>
           {
               Debug.Log("AppOpen impression recorded");
           };
           ad.OnAdClicked += () =>
           {
               Debug.Log("AppOpen ad clicked");
           };
           ad.OnAdFullScreenContentOpened += () =>
           {
               Debug.Log("AppOpen opened full screen content");
           };
           ad.OnAdFullScreenContentClosed += () =>
           {
               this.appOpenAd = null;
               LoadAppOpenAd();
               Debug.Log("AppOpen closed full screen content");
           };
           ad.OnAdFullScreenContentFailed += (AdError error) =>
           {
               this.appOpenAd = null;
               LoadAppOpenAd();
               Debug.LogError("AppOpen failed to open full screen content: " + error);
           };
       });
    }

    public void ShowAppOpenAd()
    {
        if (this.appOpenAd != null && this.appOpenAd.CanShowAd())
        {
            this.appOpenAd.Show();
        }
        else
        {
            Debug.Log("AppOpen ad is not ready yet");
        }
    }
    #endregion
}
