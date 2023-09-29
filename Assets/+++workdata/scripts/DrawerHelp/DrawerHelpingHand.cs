using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    public class DrawerHelpingHand : MonoBehaviour
    {
        [SerializeField] float timer;
        [SerializeField] bool shouldHelp = true;
        [SerializeField] GameObject hand;

        public void StartTimer()
        {
            StartCoroutine(HelpTimer());
        }

        IEnumerator HelpTimer()
        {
            yield return new WaitForSeconds(timer);
            if (shouldHelp)
                hand.SetActive(true);
        }

        public void SetShouldHelp(bool condition)
        {
            shouldHelp = condition;
            if (!shouldHelp)
                hand.SetActive(false);
        }
    }
}
