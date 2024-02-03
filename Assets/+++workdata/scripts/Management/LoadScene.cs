using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Scenes sceneToLoad = Scenes.EndScreen;
    [SerializeField] Scenes sceneToUnload= Scenes.Gameplay;
    public void LoadGivenScene()
    {
        SceneLoader.LoadScene(sceneToLoad);
        SceneLoader.UnloadScene(sceneToUnload);
    }
    public void LoadGivenScene(Scenes _sceneToLoad)
    {
        SceneLoader.LoadScene(_sceneToLoad);
        SceneLoader.UnloadScene(sceneToUnload);
    }
}
