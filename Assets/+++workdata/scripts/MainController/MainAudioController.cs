using UnityEngine;

public class MainAudioController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip currentlyPlaying, kasetteClip, gitarreClip, defaultClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentlyPlaying = defaultClip;
    }
    public void ChangeToKasette()
    {
        currentlyPlaying = kasetteClip;
        audioSource.clip = currentlyPlaying;
        audioSource.Play();
        audioSource.volume = 0.2f;
    }

    public void ChangeToGuitar()
    {
        currentlyPlaying = gitarreClip;
        audioSource.clip = currentlyPlaying;
        audioSource.Play();
        audioSource.volume = 0.5f;
    }

    public void stopMusic()
    {
        audioSource.Pause();
    }

    public void unstopMusic()
    {
        audioSource.UnPause();
    }

    public void ChangeToDefault()
    {
        currentlyPlaying = defaultClip;
        audioSource.clip = currentlyPlaying;
        audioSource.Play();
    }
}
