using System.Collections;
using UnityEngine;

public class EndscreenManager : MonoBehaviour
{
    [SerializeField] CanvasGroup[] imagesFirstPart;
    [SerializeField] CanvasGroup[] imagesSecondPart;

    [SerializeField] float defaultInterval = 4;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        for (int i = 0; i < imagesFirstPart.Length; i++)
        {
            StartCoroutine(FadeInGroup(imagesFirstPart[i]));

            yield return new WaitForSeconds(defaultInterval);
        }

        for (int i = 0; i < imagesFirstPart.Length; i++)
        {
            StartCoroutine(FadeOutGroup(imagesFirstPart[i]));
        }

        yield return new WaitForSeconds(defaultInterval);

        for (int i = 0; i < imagesSecondPart.Length; i++)
        {
            StartCoroutine(FadeInGroup(imagesSecondPart[i]));

            yield return new WaitForSeconds(defaultInterval);
        }
    }

    IEnumerator FadeInGroup(CanvasGroup canvasGroup)
    {
        float fadeTime = 0;

        while (fadeTime < defaultInterval)
        {
            fadeTime += Time.deltaTime;
            canvasGroup.alpha = fadeTime / defaultInterval;
            yield return null;
        }
    }

    IEnumerator FadeOutGroup(CanvasGroup canvasGroup)
    {
        float fadeTime = 0;

        while (fadeTime < defaultInterval)
        {
            fadeTime += Time.deltaTime;
            canvasGroup.alpha = -(-1 + Mathf.Clamp01(fadeTime / defaultInterval));
            yield return null;
        }
    }

    public void ToMain()
    {
        SceneLoader.Instance.LoadSceneViaIndex(Scenes.MainMenu);
        SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
    }
}
