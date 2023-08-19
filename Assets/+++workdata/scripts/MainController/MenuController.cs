using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Access
    public GameObject main, options, credits, musik;
    public AudioMixer audioMixer;
    SoundSave soundSave;
    public GameObject soundSlider;

    public float currentVolume;
    #endregion


    private void Start()
    {
        main.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
        musik.SetActive(false);
        if (GameObject.Find("SoundSaveMain").GetComponent<SoundSave>().enabled)
        {
            soundSave = GameObject.Find("SoundSaveMain").GetComponent<SoundSave>();
            currentVolume = soundSave.volume;
            soundSlider.GetComponentInChildren<Slider>().value = currentVolume;
        }
    }

    public void PlayGame()   //loads the game scene when activating the button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(gameObject);
    }

    public void QuitGame()  //quits the game
    {
        Application.Quit();
    }

    public void ToOptions()
    {
        options.SetActive(true);
        main.SetActive(false);
    }

    public void ToMain()
    {
        main.SetActive(true);
        credits.SetActive(false);
        options.SetActive(false);
    }

    public void ToCredits()
    {
        credits.SetActive(true);
        main.SetActive(false);
        musik.SetActive(false);
    }

    public void ToMusic()
    {
        musik.SetActive(true);
        credits.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        currentVolume = volume;
    }

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
