using UnityEngine;
using UnityEngine.UI;

namespace JustASpoonful
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Cashes
        [Header("Menu")]
        [SerializeField] GameObject[] menuObjects;
        [Header("Settings")]
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider sfxSlider;
        [SerializeField] Toggle screenToggle;
        #endregion

        #region Variables

        #endregion

        void Start() => SubscribeFunctions();

        void SubscribeFunctions()
        {
            GameSettings.Instance.SubscribeMusicSlider(musicSlider);
            GameSettings.Instance.SubscribeSFXSlider(sfxSlider);
            GameSettings.Instance.SubscribeFullscreenToggle(screenToggle);
        }

        /// <summary>
        /// Enables one given object and disables the rest
        /// </summary>
        public void EnableMenuObject(GameObject objectToEnable)
        {
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(menuObjects[i] == objectToEnable);
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void OpenURL(string link)
        {
            Application.OpenURL(link);
        }
    }
}
