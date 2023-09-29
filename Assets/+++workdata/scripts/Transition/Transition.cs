using UnityEngine;

namespace JustASpoonful
{
    public class Transition : MonoBehaviour
    {
        #region Cashed vars
        Animator anim;
        #endregion

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void FadeOut(float delay)
        {
            Invoke(nameof(FadeOut), delay);
        }

        public void FadeOut()
        {
            anim.ResetTrigger("fadeIn");
            anim.SetTrigger("fadeOut");
        }

        public void FadeIn(float delay)
        {
            Invoke(nameof(FadeIn), delay);
        }

        public void FadeIn()
        {
            anim.ResetTrigger("fadeOut");
            anim.SetTrigger("fadeIn");
        }
    }
}
