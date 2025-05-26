using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] bool disableColOnInteract = true;
    [SerializeField] bool neededForWin = true;
    [Tooltip("Will invoke onSolved if null and clicked")]
    [SerializeField] GameObject uIObject;
    [SerializeField] GameObject starObj;
    [SerializeField] UnityEvent onSolved;
    [SerializeField] UnityEvent onAnimPlayed;
    [SerializeField] int clickAmountToSolve = 1;
    int clickAmount;
    public bool solved { get; private set; }

    #region Cashed vars
    Collider2D col;
    #endregion

    void Awake()
    {
        col = GetComponent<Collider2D>();
        if (neededForWin)
            GameStateManager.Instance.SubscribeInteractable(this);
    }

    public void OnInteract()
    {
        if (!uIObject)
            OnSolved();

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

        clickAmount++;
        if (clickAmount >= clickAmountToSolve)
            GameStateManager.Instance.DesubscribeInteractable(this);

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
            //Debug.Log("Has no assigned Interactable", gameObject);
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

