using UnityEngine;

namespace JustASpoonful
{
    public class MainMenuManager : MonoBehaviour
    {
        #region Cashes
        [SerializeField] GameObject[] menuObjects;
        [SerializeField] GameObject menuBG;
        #endregion

        #region Variables

        #endregion

        /// <summary>
        /// Enables one given object and disables the rest
        /// </summary>
        public void EnableMenuObject(GameObject objectToEnable)
        {
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(menuObjects[i] == objectToEnable);
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void StartCutscene()
        {
            menuBG.SetActive(false);
            for (int i = 0; i < menuObjects.Length; i++)
            {
                menuObjects[i].SetActive(false);
            }
        }
    }
}
