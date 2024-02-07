using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

namespace JustASpoonful
{
    public class MobileManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> screenHistory;
        [SerializeField] GameObject mobile;
        [SerializeField] GameObject homeScreen;

        [SerializeField] GameObject currentScreen;

        void Start()
        {
            currentScreen = homeScreen;
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
            screenHistory.Add(currentScreen);
            currentScreen = screen;

            DeactivateHistoryExcept(screen);

            currentScreen.SetActive(true);
        }

         void DeactivateHistoryExcept(GameObject screen)
        {
            for (int i = 0; i < screenHistory.Count; i++)
            {
                screenHistory[i].SetActive(screenHistory[i] == screen);
            }
        }

        public void BackScreen()
        {
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
            screenHistory.Add(currentScreen);

            currentScreen = homeScreen;
            DeactivateHistoryExcept(homeScreen);
            homeScreen.SetActive(true);
        }
    }
}
