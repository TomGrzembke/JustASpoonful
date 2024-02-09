using System.Collections;
using UnityEngine;

public class EndscreenManager : MonoBehaviour
{
    [SerializeField] GameObject[] imagesFirstPart;
    [SerializeField] GameObject[] imagesSecondPart;

    [SerializeField] float defaultInterval = 4;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(defaultInterval);

        for (int i = 0; i < imagesFirstPart.Length; i++)
        {
            imagesFirstPart[i].SetActive(true);

            yield return new WaitForSeconds(defaultInterval);
        }

        for (int i = 0; i < imagesFirstPart.Length; i++)
        {
            imagesFirstPart[i].SetActive(false);
        }

        for (int i = 0; i < imagesSecondPart.Length; i++)
        {
            imagesSecondPart[i].SetActive(true);

            yield return new WaitForSeconds(defaultInterval);
        }

        ToMain();
    }

    public void SkipCutscene()
    {
        StopAllCoroutines();
        ToMain();
    }

    public void ToMain()
    {
        SceneLoader.Instance.LoadSceneViaIndex(Scenes.MainMenu);
        SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
    }
}
