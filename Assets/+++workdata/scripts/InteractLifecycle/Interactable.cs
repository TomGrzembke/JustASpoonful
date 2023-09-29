using UnityEngine;
using UnityEngine.Events;

namespace JustASpoonful
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] bool disableColOnInteract = true;
        [SerializeField] GameObject uIObject;
        [SerializeField] GameObject starObj;
        [SerializeField] UnityEvent onSolved;
        [SerializeField] UnityEvent onAnimPlayed;
        public bool solved { get; private set; }

        #region Cashed vars
        Collider2D col;
        #endregion

        void Awake()
        {
            col = GetComponent<Collider2D>();
        }

        public void OnInteract()
        {
            if (uIObject == null)
            {
                OnSolved();
            }
            else if (uIObject.activeInHierarchy)
            {
                uIObject.SetActive(false);
                OnSolved();
            }
        }

        void OnSolved()
        {
            solved = true;
            starObj.SetActive(false);
            onSolved?.Invoke();
            if (disableColOnInteract)
                col.enabled = false;
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
                print(gameObject.name + " has no assigned Interactable");
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

            if (GetUIObject() == null)
            {
                starObj.SetActive(true);
            }
            else if (uIObject.activeInHierarchy)
                starObj.SetActive(true);
        }

        public void AnimFinished()
        {
            onAnimPlayed?.Invoke();
        }

        public void SetUIObj(GameObject newUIObj)
        {
            uIObject = newUIObj;
        }
    }
}
