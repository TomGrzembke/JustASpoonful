using UnityEngine;
using UnityEngine.Events;

namespace JustASpoonful
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] GameObject uIObject;
        [SerializeField] GameObject starObj;
        [SerializeField] UnityEvent onSolved;
        public bool solved { get; private set; }

        public void OnInteract()
        {
            if (uIObject == null)
            {
                OnSolved();
            }

            if (uIObject.activeInHierarchy)
            {
                uIObject.SetActive(false);
                OnSolved();
            }
        }

        void OnSolved()
        {
            solved = true;
            starObj.SetActive(false);
            onSolved.Invoke();
        }

        public GameObject GetUIObject()
        {
            if (CheckAssigned(uIObject))
                return uIObject;
            else
                return null;
        }
        public bool CheckAssigned(GameObject obj)
        {
            if (obj != null)
                return true;
            else
            {
                Debug.LogWarning("At " + gameObject.name + obj.ToString() + " has no assigned Interactable");
                return false;
            }
        }

        public void OnHover(bool state)
        {
            if (!state)
            {
                starObj.SetActive(false);
                return;
            }

            if (uIObject.activeInHierarchy)
                starObj.SetActive(true);
        }
    }
}
