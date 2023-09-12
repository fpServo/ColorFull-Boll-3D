using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class BannerADS : MonoBehaviour
{
    private BannerView bannerview;

    [System.Obsolete]
    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();

    }

    [System.Obsolete]
    private void RequestBanner()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2574564279542180/5848465388";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-2574564279542180/9053498630";
#else
        string adUnitId = "unexpected_platform";
#endif
        this.bannerview = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerview.LoadAd(request);
    }
}
