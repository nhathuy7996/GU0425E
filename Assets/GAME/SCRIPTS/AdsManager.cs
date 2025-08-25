using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdsManager : Singleton<AdsManager>
{
    private BannerView bannerView;
    void Init()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            Debug.Log("AdMob Initialized");
            LoadBanner();
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
        };
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner failed to load: " + error);
            LoadBanner();
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
}
