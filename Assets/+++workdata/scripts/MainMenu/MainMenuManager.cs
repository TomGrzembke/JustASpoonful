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
        /// <summary> Will wait the delay amount of time and play a transition if you specify one at the second index </summary> 
        public void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }


        /// <summary> Will wait the delay amount of time and play a transition if you specify one at the second index </summary>
        public void LoadScene(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }

        /// <summary> Will wait the delay amount of time </summary>
        public void LoadScene(int sceneID, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(sceneID, delay));
        }

        /// <summary> Will wait the delay amount of time </summary>   
        public void LoadScene(string scene, float delay)
        {
            StartCoroutine(LoadSceneWithDelay(scene, delay));
        }

        /// <summary> Will wait the delay amount of time </summary>   
        IEnumerator LoadSceneWithDelay(string scene, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(scene);
        }

        /// <summary> Will wait the delay amount of time </summary>   
        IEnumerator LoadSceneWithDelay(int sceneID, float delay)
        {
            transitionAnim.SetTrigger("fadeOut");
            yield return new WaitForSeconds(delay);
            LoadScene(sceneID);
        }
        #endregion
    }
}
