using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsMAXManager : Singleton<AdsMAXManager>
{
    void Init()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            // AppLovin SDK is initialized, start loading ads.
            Debug.Log("MAX SDK Initialized");
        };
        MaxSdk.InitializeSdk();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    #region Banner
    public void InitializeBannerAds()
    {
        // Banners are automatically sized to 320×50 on phones and 728×90 on tablets
        // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
        var adViewConfiguration = new MaxSdk.AdViewConfiguration(MaxSdk.AdViewPosition.BottomCenter);
        MaxSdk.CreateBanner("", adViewConfiguration);
        MaxSdkCallbacks.Banner.OnAdLoadedEvent += OnBannerAdLoadedEvent;
        MaxSdkCallbacks.Banner.OnAdLoadFailedEvent += OnBannerAdLoadFailedEvent;
        MaxSdkCallbacks.Banner.OnAdClickedEvent += OnBannerAdClickedEvent;
        MaxSdkCallbacks.Banner.OnAdRevenuePaidEvent += OnBannerAdRevenuePaidEvent;
        MaxSdkCallbacks.Banner.OnAdExpandedEvent += OnBannerAdExpandedEvent;
        MaxSdkCallbacks.Banner.OnAdCollapsedEvent += OnBannerAdCollapsedEvent;
    }

    private void OnBannerAdLoadedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {
        Debug.Log("Banner loaded");
        MaxSdk.ShowBanner(adUnitId);
    }

    private void OnBannerAdLoadFailedEvent(string adUnitId, MaxSdk.ErrorInfo errorInfo)
    {

    }

    private void OnBannerAdClickedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {

    }

    private void OnBannerAdRevenuePaidEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {

    }

    private void OnBannerAdExpandedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {

    }

    private void OnBannerAdCollapsedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {

    }
    #endregion

    #region Interstitial
    int retryAttempt;

    public void InitializeInterstitialAds()
    {
        // Attach callback
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHiddenEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialAdFailedToDisplayEvent;

        // Load the first interstitial
        LoadInterstitial();
    }

    private void LoadInterstitial()
    {
        MaxSdk.LoadInterstitial("ad unit ID");
    }

    private void OnInterstitialLoadedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {
        // Interstitial ad is ready for you to show. MaxSdk.IsInterstitialReady(adUnitId) now returns 'true'

        // Reset retry attempt
        retryAttempt = 0;
    }

    private void OnInterstitialLoadFailedEvent(string adUnitId, MaxSdk.ErrorInfo errorInfo)
    {
        // Interstitial ad failed to load
        // AppLovin recommends that you retry with exponentially higher delays, up to a maximum delay (in this case 64 seconds)

        retryAttempt++;
        double retryDelay = System.Math.Pow(2, System.Math.Min(6, retryAttempt));

        Invoke("LoadInterstitial", (float)retryDelay);
    }

    private void OnInterstitialDisplayedEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {

    }

    private void OnInterstitialAdFailedToDisplayEvent(string adUnitId, MaxSdk.ErrorInfo errorInfo, MaxSdk.AdInfo adInfo)
    {
        // Interstitial ad failed to display. AppLovin recommends that you load the next ad.
        LoadInterstitial();
    }

    private void OnInterstitialClickedEvent(string adUnitId, MaxSdk.AdInfo adInfo) { }

    private void OnInterstitialHiddenEvent(string adUnitId, MaxSdk.AdInfo adInfo)
    {
        // Interstitial ad is hidden. Pre-load the next ad.
        LoadInterstitial();
    }
    
    public void ShowInterstitial()
    {
        if (MaxSdk.IsInterstitialReady("ad unit ID"))
        {
            MaxSdk.ShowInterstitial("ad unit ID");
        }
    }
    #endregion
}
