using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobController : MonoBehaviour
{
#if UNITY_IOS
    private string appId = "ca-app-pub-4962234576866611~4393008713";
    private string interstitionalId = "ca-app-pub-4962234576866611/9262192018";
#else
    private string appId = "ca-app-pub-4962234576866611~4393008713";
    private string interstitionalId = "ca-app-pub-4962234576866611/9262192018";
#endif
    
    private InterstitialAd _interstitialAd;

    public static int adCounter=0;

    void Start(){
        RequestConfiguration requestConfiguration =
            new RequestConfiguration.Builder()
            .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => {
          LoadLoadInterstitialAd();
        });
    }

    public bool ShowIntersitionalAd(){
        if (_interstitialAd==null) return false;

        return showIntersitionalUnityAd();
    }

    public void LoadLoadInterstitialAd()
    {
        if (_interstitialAd != null)
        {
                _interstitialAd.Destroy();
                _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        var adRequest = new AdRequest();

        InterstitialAd.Load(interstitionalId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                _interstitialAd = ad;

                RegisterEventHandlers(_interstitialAd);
                RegisterReloadHandler(_interstitialAd);
            });
    }

      public bool showIntersitionalUnityAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd() && adCounter % 2 == 0)
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();

            adCounter++;

            return true;
        }
        else
        {
            adCounter++;

            return false;
        }
      }

      private void RegisterEventHandlers(InterstitialAd interstitialAd)
      {
          interstitialAd.OnAdPaid += (AdValue adValue) =>
          {
              Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                  adValue.Value,
                  adValue.CurrencyCode));
          };

          interstitialAd.OnAdImpressionRecorded += () =>
          {
              Debug.Log("Interstitial ad recorded an impression.");
          };

          interstitialAd.OnAdClicked += () =>
          {
              Debug.Log("Interstitial ad was clicked.");
          };

          interstitialAd.OnAdFullScreenContentOpened += () =>
          {
              Debug.Log("Interstitial ad full screen content opened.");
          };

          interstitialAd.OnAdFullScreenContentClosed += () =>
          {
              Debug.Log("Interstitial ad full screen content closed.");
          };

          interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
          {
              Debug.LogError("Interstitial ad failed to open full screen content " +
                          "with error : " + error);
          };
      }

      private void RegisterReloadHandler(InterstitialAd interstitialAd)
      {
          interstitialAd.OnAdFullScreenContentClosed += () =>
          {
              Debug.Log("Interstitial Ad full screen content closed.");

              LoadLoadInterstitialAd();
          };

          interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
          {
              Debug.LogError("Interstitial ad failed to open full screen content " +
                          "with error : " + error);

              LoadLoadInterstitialAd();
          };
      }
}
