using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustASpoonful
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] GameObject[] images;
        [SerializeField] float[] imageDuration;
        [SerializeField] float defaultInterval = 4;
        [SerializeField] MainMenuManager mainMenuManager;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(CheckIfCustomIntervalIsSet(0));

            for (int i = 1; i < images.Length; i++)
            {
                images[i].SetActive(true);

                yield return new WaitForSeconds(CheckIfCustomIntervalIsSet(i));
            }
            LoadNextScene();
        }

        float CheckIfCustomIntervalIsSet(int index)
        {
            return imageDuration[index] != 0 ? imageDuration[index] : defaultInterval;
        }

        public void SkipCutscene()
        {
            StopAllCoroutines();
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            mainMenuManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,1);
        }
    }

}
