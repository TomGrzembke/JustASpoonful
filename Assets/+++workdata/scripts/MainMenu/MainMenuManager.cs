using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustASpoonful
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Cashes
        [SerializeField] GameObject[] menuObjects;
        [SerializeField] GameObject menuBG;
        [SerializeField] Animator transitionAnim;
        #endregion

        #region Variables

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
            Application.Quit();
        }

        public void StartCutscene()
        {
            menuBG.SetActive(false);
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(false);
            }
        }

        #region Loadscene overload
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }

        public void LoadScene(int sceneID, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(sceneID, delay));
        }

        public void LoadScene(string scene, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(scene, delay));
        }

        IEnumerator LoadSceneWithDelay(string scene, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(scene);
        }
        IEnumerator LoadSceneWithDelay(int sceneID, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(sceneID);
        }
        #endregion
    }
}
