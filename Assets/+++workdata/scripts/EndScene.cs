using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    #region stats
    public int currentPicture;
    #endregion

    #region Access
    public GameObject[] pictures;
    public GameObject backToMenu, next;
    #endregion

    public void NextPicture()
    {
        if (currentPicture < 5)
        {
            pictures[currentPicture].SetActive(true);
            currentPicture++;
        }
        else if (currentPicture >= 5)
        {
            pictures[0].SetActive(false);
            pictures[1].SetActive(false);
            pictures[2].SetActive(false);
            pictures[3].SetActive(false);
            pictures[4].SetActive(false);
            pictures[currentPicture].SetActive(true);
            currentPicture++;

            if (currentPicture == 7)
            {
                backToMenu.SetActive(true);
                next.SetActive(false);
            }

        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
