using UnityEngine;

namespace JustASpoonful
{
    public class MainMenuParser : MonoBehaviour
    {
        #region Cashes
        [Header("Menu")]
        [SerializeField] GameObject[] menuObjects;
        #endregion

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
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif PLATFORM_WEBGL
            
            Screen.fullScreen = false;
            Application.Quit();
#else
            Application.Quit();
#endif
        }

        public void NextScene()
        {
            SceneLoader.Instance.LoadSceneViaIndex(gameObject.scene.buildIndex + 1);
            SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
            TouchCheck.Instance.StopCheck();
        }

        public void OpenURL(string link)
        {
            Application.OpenURL(link);
        }
    }
}
