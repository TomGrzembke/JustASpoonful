using MyBox;
using System.Linq;
using UnityEngine.SceneManagement;

public static class SceneReferenceExtensions
{
    /// <summary> Custom made method to acces a build index id through SceneReference</summary>
    public static int GetSceneIndex(this SceneReference scene)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string testedName = path.Split('/').Last().Replace(".unity", string.Empty);
            if (testedName == scene.SceneName)
                return i;
        }
        return -1;
    }
}