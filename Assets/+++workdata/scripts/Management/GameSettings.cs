using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        OnScreenToggleChanged(ScreenToggle);
    }

    #region Serilized Fields
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] float onSFXChangedCooldown = 0.1f;
    #endregion

    #region private
    float MusicVolume
    {
        get => PlayerPrefs.GetFloat("musicVolume");
        set
        {
            audioMixer.SetFloat("musicVolume", value);
            PlayerPrefs.SetFloat("musicVolume", value);
        }
    }
    float SFXVolume
    {
        get => PlayerPrefs.GetFloat("sfxVolume");
        set
        {
            audioMixer.SetFloat("sfxVolume", value);
            PlayerPrefs.SetFloat("sfxVolume", value);
        }
    }
    bool ScreenToggle
    {
        get => PlayerPrefs.GetInt("fullscreenID") == 0;
        set
        {
            PlayerPrefs.SetInt("fullscreenID", value ? 0 : 1);
        }
    }

    

    Slider musicSlider, sfxSlider;
    Toggle screenToggle;
    Coroutine sfxChangedCoroutine;
    bool sfxEmitSound;
    #endregion

    public void OnMusicSliderChanged(float _ = 0)
    {
        float volume = musicSlider.value;

        if (volume == musicSlider.minValue)
            volume = -60;

        MusicVolume = volume;
    }

    public void OnSfxSliderChanged(float _ = 0)
    {
        float volume = sfxSlider.value;

        if (volume == sfxSlider.minValue)
            volume = -60;

        SFXVolume = volume;
        sfxSlider.value = volume;

        if (sfxChangedCoroutine == null && sfxEmitSound)
            sfxChangedCoroutine = StartCoroutine(PlayOnSFXChangedCor());
        sfxEmitSound = true;
    }

    public void OnScreenToggleChanged(bool condition)
    {
        ScreenToggle = condition;

#if UNITY_EDITOR
        EditorWindow.focusedWindow.maximized = condition;
#else
        Screen.fullScreen = condition;
#endif

    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }

    IEnumerator PlayOnSFXChangedCor()
    {

        yield return new WaitForSecondsRealtime(onSFXChangedCooldown);
        sfxChangedCoroutine = null;
    }

    public void SubscribeMusicSlider(Slider _musicSlider)
    {
        musicSlider = _musicSlider;
        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        musicSlider.value = MusicVolume;
    }

    public void SubscribeSFXSlider(Slider _sfxSlider)
    {
        sfxSlider = _sfxSlider;
        sfxSlider.value = SFXVolume;
        sfxSlider.onValueChanged.AddListener(OnSfxSliderChanged);
    }

    public void SubscribeFullscreenToggle(Toggle _fullscreenToggle)
    {
        screenToggle = _fullscreenToggle;
        screenToggle.isOn = ScreenToggle;

        screenToggle.onValueChanged.AddListener(OnScreenToggleChanged);
    }
}
