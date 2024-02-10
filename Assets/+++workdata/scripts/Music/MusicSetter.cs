using UnityEngine;

namespace JustASpoonful
{
    public class MusicSetter : MonoBehaviour
    {
        [SerializeField] bool onStart;
        [SerializeField] AudioClip clip;

        void Start()
        {
            if (onStart)
                SwitchMusic();
        }

        public void SwitchMusic()
        {
            MusicManager.Instance.PlaySong(clip);
        }
    }
}
