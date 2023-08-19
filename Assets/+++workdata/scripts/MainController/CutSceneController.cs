using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour
{
    #region stats
    public int currentPicture;
    #endregion

    #region Access
    public GameObject[] pictures;
    public GameObject lavaLamp, arrow, filter;
    #endregion

    public void NextPicture()
    {
        if (currentPicture < 7)
        {
            pictures[currentPicture].SetActive(true);
            pictures[currentPicture - 1].SetActive(false);
            currentPicture++;
            filter.SetActive(true);
        }
        else if (currentPicture == 7)
        {
            pictures[currentPicture - 1].SetActive(false);
            pictures[currentPicture].SetActive(true);
            currentPicture++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            lavaLamp.SetActive(true);
            arrow.SetActive(false);
        }

        if (currentPicture == 2)
        {
            arrow.SetActive(false);
            Invoke("ArrowActive", 3f);
        }
    }

    void ArrowActive()
    {
        arrow.SetActive(true);
    }
}


