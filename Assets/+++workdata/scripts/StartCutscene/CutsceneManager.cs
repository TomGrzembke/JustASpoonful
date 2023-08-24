using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustASpoonful
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] GameObject[] cutsceneImage;
        [SerializeField] float cutsceneInterval = 2f;
        [SerializeField] MainMenuManager mainMenuManager;

        IEnumerator Start()
        {
            for (int i = 1; i < cutsceneImage.Length; i++)
            {
                yield return new WaitForSeconds(cutsceneInterval);
                cutsceneImage[i].SetActive(true);
            }
            LoadNextScene();
        }

        public void SkipCutscene()
        {
            StopAllCoroutines();
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            mainMenuManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
