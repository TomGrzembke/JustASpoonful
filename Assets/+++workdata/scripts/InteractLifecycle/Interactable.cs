using UnityEngine;
using UnityEngine.Events;

/// <summary> Dispatches events onInteract depending on Settings </summary>
public class Interactable : MonoBehaviour
{
    [Header("Settings")] [SerializeField] bool disableColOnInteract = true;
    [SerializeField] bool neededForWin = true;
    [SerializeField] int clickAmountToSolve = 1;
    [SerializeField] bool debugReferenceMissing = false;

    [SerializeField, Tooltip("Can be leftout and will be ignored then")]
    GameObject uIObject;

    [Header("References")] [SerializeField]
    GameObject starObj;


    [SerializeField] UnityEvent onSolved;
    [SerializeField] UnityEvent onInteracted;

    [SerializeField] UnityEvent onAnimPlayed;

    int clickAmount;
    bool isSolved;

    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();

        if (neededForWin && ValidateReference(GameStateManager.Instance))
        {
            GameStateManager.Instance.SubscribeInteractable(this);
        }
    }

    public void OnInteract()
    {
        if (!CanBeSolved()) return;

        onInteracted?.Invoke();

        if (ValidateReference(uIObject))
        {
            uIObject.SetActive(false);
        }

        TrySolve();
    }

    public GameObject GetUIObject()
    {
        return uIObject;
    }

    public void OnHover(bool isHovering)
    {
        bool shouldShow = isHovering && CanBeSolved();
        SetActiveHighlight(shouldShow);
    }

    void TrySolve()
    {
        clickAmount++;

        if (clickAmount < clickAmountToSolve) return;

        Solve();
    }

    void Solve()
    {
        isSolved = true;
        SetActiveHighlight(false);
        onSolved?.Invoke();

        GameStateManager.Instance.DesubscribeInteractable(this);

        if (disableColOnInteract)
        {
            col.enabled = false;
        }
    }

    bool CanBeSolved()
    {
        return !ValidateReference(uIObject) || uIObject.activeInHierarchy;
    }

    void SetActiveHighlight(bool condition)
    {
        if (!ValidateReference(starObj)) return;

        starObj.SetActive(condition);
    }

    public void AnimFinished()
    {
        onAnimPlayed?.Invoke();
    }

    public void SetUIObj(GameObject newUIObj)
    {
        uIObject = newUIObj;
    }

    public bool GetIsSolved()
    {
        return isSolved;
    }

    bool ValidateReference(Object obj)
    {
        if (obj != null) return true;

        if (debugReferenceMissing)
        {
            Debug.Log($"[{gameObject.name}] No reference in {nameof(Interactable)} component!", this);
        }

        return false;
    }
}