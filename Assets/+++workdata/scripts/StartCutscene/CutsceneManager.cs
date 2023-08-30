using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustASpoonful
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] GameObject[] cutsceneImage;
        [SerializeField] float[] cutsceneImageDuration;
        [SerializeField] float cutsceneInterval = 2f;
        [SerializeField] MainMenuManager mainMenuManager;

        IEnumerator Start()
        {
            if (cutsceneImageDuration[0] == 0)
                yield return new WaitForSeconds(cutsceneInterval);
            else
                yield return new WaitForSeconds(cutsceneImageDuration[0]);

            for (int i = 1; i < cutsceneImage.Length; i++)
            {
                cutsceneImage[i].SetActive(true);

                if (cutsceneImageDuration[i] == 0)
                    yield return new WaitForSeconds(cutsceneInterval);
                else
                    yield return new WaitForSeconds(cutsceneImageDuration[i]);
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
