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
            if (imageDuration.Length < 1)
                return defaultInterval;
            return imageDuration[index] != 0 ? imageDuration[index] : defaultInterval;
        }

        public void SkipCutscene()
        {
            StopAllCoroutines();
            LoadNextScene();
        }

        void LoadNextScene()
        {
            SceneManager.LoadScene(gameObject.scene.buildIndex + 1);
        }
    }

}
