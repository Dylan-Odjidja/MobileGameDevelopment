using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
    public BannerAdExample bannerAdExample;

    // Start is called before the first frame update
    void Start()
    {
        bannerAdExample.ShowBannerAd();
    }
}
