using UnityEngine;
using UnityEngine.UI;

public class SettingsParser : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Toggle screenToggle;

    void Start() => SubscribeFunctions();

    void SubscribeFunctions()
    {
        if (musicSlider)
            GameSettings.Instance.SubscribeMusicSlider(musicSlider);
        if (sfxSlider)
            GameSettings.Instance.SubscribeSFXSlider(sfxSlider);
        if (screenToggle)
            GameSettings.Instance.SubscribeFullscreenToggle(screenToggle);
    }
}
