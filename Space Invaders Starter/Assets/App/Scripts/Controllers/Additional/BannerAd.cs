using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{
    [Header("The position of banner over screen")]
    [SerializeField] private BannerPosition bannerPosition = BannerPosition.BOTTOM_RIGHT;

    [Space]
    [Header("ID's must be replaced banner ID's in monetization dashboard")]
    [SerializeField] private string bannerAndroidId = "Banner_Android";

    [SerializeField] private string bannerIOSId = "Banner_iOS";

    [Space]
    private string currentPlatformBannerId = null;

    private void Start()
    {
#if UNITY_ANDROID
        currentPlatformBannerId = bannerAndroidId;
#elif UNITY_IOS
        currentPlatformBannerId = bannerIOSId;
#endif
        //Setting the position of banner
        Advertisement.Banner.SetPosition(bannerPosition);

        //That is the load and error handling options of banner
        BannerLoadOptions bannerLoadOptions = new BannerLoadOptions
        {
            
        };

        Advertisement.Banner.Load(currentPlatformBannerId, bannerLoadOptions);

        BannerOptions showBannerOptions = new BannerOptions
        {
            
        };

        Advertisement.Banner.Show(currentPlatformBannerId, showBannerOptions);
    }


}

