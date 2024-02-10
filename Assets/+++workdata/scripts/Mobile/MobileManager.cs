using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class MobileManager : MonoBehaviour
    {
        [SerializeField] GameObject mobile;
        [SerializeField] GameObject homeScreen;
        [SerializeField] GameObject settingsScreen;

        [Header("Runtime")]
        [SerializeField] GameObject currentScreen;
        [SerializeField] List<GameObject> screenHistory;

        GameControl input;

        void Awake()
        {
            input = new();

            input.GameController.Menu.performed += ctx => ToggleSettings();
        }

        void Start()
        {
            currentScreen = homeScreen;
        }

        void ToggleSettings()
        {
            if (!settingsScreen.activeInHierarchy)
            {
                MobileSetActive(true);
                if (currentScreen)
                {
                    AddHistory(currentScreen);
                    currentScreen.SetActive(false);

                    currentScreen = settingsScreen;
                }
            }
            else
            {
                MobileSetActive(false);
                return;
            }


            settingsScreen.SetActive(!settingsScreen.activeInHierarchy);
        }

        public void MobileSetActive(bool condition)
        {
            mobile.SetActive(condition);
        }

        public void MobileToggle()
        {
            mobile.SetActive(!mobile.activeInHierarchy);
        }

        public void SwitchScreen(GameObject screen)
        {
            AddHistory(currentScreen);
            currentScreen = screen;

            DeactivateHistoryExcept(screen);

            currentScreen.SetActive(true);
        }


        public void BackScreen()
        {
            if (screenHistory.Count < 1) return;

            if (screenHistory[screenHistory.Count - 1] == currentScreen)
                screenHistory.RemoveAt(screenHistory.Count - 1);

            if (screenHistory.Count < 1) return;

            currentScreen.SetActive(false);

            GameObject lastScreen = screenHistory[screenHistory.Count - 1];
            DeactivateHistoryExcept(lastScreen);
            currentScreen = lastScreen;

            screenHistory.RemoveAt(screenHistory.Count - 1);
        }

        public void HomeScreen()
        {
            currentScreen.SetActive(false);
            AddHistory(currentScreen);

            currentScreen = homeScreen;
            DeactivateHistoryExcept(homeScreen);
            homeScreen.SetActive(true);
        }

        public void AddHistory(GameObject historyObject)
        {
            if (historyObject == null) return;

            if (screenHistory.Count > 0)
                if (screenHistory[screenHistory.Count - 1] == historyObject) return;

            screenHistory.Add(historyObject);
        }

        void DeactivateHistoryExcept(GameObject screen)
        {
            for (int i = 0; i < screenHistory.Count; i++)
            {
                screenHistory[i].SetActive(screenHistory[i] == screen);
            }
        }

        public void ToMain()
        {
            SceneLoader.Instance.LoadSceneViaIndex(Scenes.MainMenu);
            SceneLoader.Instance.UnloadSceneViaIndex(gameObject.scene.buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }

        void OnEnable()
        {
            input.Enable();
        }
        void OnDisable()
        {
            input.Disable();
        }
    }
}
