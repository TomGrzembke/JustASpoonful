using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return SceneLoader.LoadScene(Scenes.Manager);

        if (!SceneManager.GetSceneByBuildIndex(Scenes.Gameplay.GetIndex()).IsValid())
            yield return SceneLoader.LoadScene(Scenes.MainMenu);
        else
            yield return SceneLoader.UnloadScene(Scenes.MainMenu);
    }

}