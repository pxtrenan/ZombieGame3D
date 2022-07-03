using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    InterstitialAd interstitial;

    
    void Start()
    {
        
        RequestBanner();
        RequestInterstitial();
    }

    public void ShowInterstitialAd()
    {
        //Mostrando o anuncio
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            Debug.Log("anuncio");
        }

    }


    private void RequestBanner()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3526702404345714/8508097489";
#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
			string adUnitId = "unexpected_platform";
#endif

        //Criando um banner 320x50 no topo da tela
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3526702404345714/9438035770";
#elif UNITY_IPHONE
			string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
			string adUnitId = "unexpected_platform";
#endif

        // Iniciando um anuncio em tela cheia apos alguma acao
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }

}