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
        GameSettings.Instance.SubscribeMusicSlider(musicSlider);
        GameSettings.Instance.SubscribeSFXSlider(sfxSlider);
        GameSettings.Instance.SubscribeFullscreenToggle(screenToggle);
    }
}
