using UnityEngine;

public class GameSceneInitializer : MonoBehaviour
{
    void Awake()
    {
        SceneLoader.Instance.LoadSceneViaIndex(Scenes.Manager);
    }
}
