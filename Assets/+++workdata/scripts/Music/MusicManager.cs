using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance;

        [SerializeField] AudioSource source;
        [SerializeField] float blendTime = 2;

        float initialVolume;

        void Awake()
        {
            Instance = this;
            initialVolume = source.volume;
        }

        public void PlaySong(AudioClip clip)
        {
            if (source.clip != clip)
                StartCoroutine(BlendSongs(clip));
        }

        IEnumerator BlendSongs(AudioClip clip)
        {
            float blendedTime = 0;
            float currentVolume = source.volume;

            while (blendedTime < blendTime)
            {
                blendedTime += Time.deltaTime;
                source.volume = Mathf.Lerp(currentVolume, 0, blendedTime / blendTime);
                yield return null;
            }

            source.clip = clip;
            if (!source.isPlaying)
                source.Play();

            blendedTime = 0;
            while (blendedTime < blendTime)
            {
                blendedTime += Time.deltaTime;
                source.volume = Mathf.Lerp(0, initialVolume, blendedTime / blendTime);
                yield return null;
            }
        }
    }
}
