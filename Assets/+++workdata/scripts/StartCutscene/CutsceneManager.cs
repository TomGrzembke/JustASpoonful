using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    public class CutsceneManager : MonoBehaviour
    {
        [SerializeField] GameObject[] images;
        [SerializeField] float[] imageDuration;
        [SerializeField] float defaultInterval = 4;
        [SerializeField] bool switchScene = true;

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
            if (!switchScene) return;
            SceneLoader.Instance.LoadSceneViaIndex(gameObject.scene.buildIndex + 1);
            SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
        }

        public void ToMain()
        {
            SceneLoader.Instance.LoadSceneViaIndex(Scenes.MainMenu);
            SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
        }
    }

}
