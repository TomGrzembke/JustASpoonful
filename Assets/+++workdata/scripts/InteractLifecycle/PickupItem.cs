using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary> Handles the Transition/"Pickup" between world and UI for an object</summary>
public class PickupItem : MonoBehaviour
{
    [Header("Settings")] [SerializeField] Interactable interactable;

    [SerializeField, Tooltip("Used when multiple objects are usable for the object")]
    bool reenableVisualAfterSolved;

    List<GameObject> alternativeUIObjects = new();
    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void Pickup()
    {
        SetWorldObjectVisible(false);

        SetUIObjectVisible(true);

        GameStateManager.Instance.AddPickupable(this);
    }

    public void Pickup(GameObject alternUIObj)
    {
        alternativeUIObjects.Add(alternUIObj);
        SetWorldObjectVisible(false);

        SetAlternativeUIObjectVisible(alternUIObj, true);

        GameStateManager.Instance.AddPickupable(this);
    }

    public void Drop()
    {
        bool shouldBeVisible = !interactable.solved || reenableVisualAfterSolved;

        SetWorldObjectVisible(shouldBeVisible);

        if (interactable.solved)
        {
            col.enabled = false;
        }

        //Clean UI
        SetUIObjectVisible(false);
        ClearAlternativeUI();
    }

    void ClearAlternativeUI()
    {
        foreach (var uiObj in alternativeUIObjects)
        {
            if (!ValidateReference(uiObj)) continue;

            uiObj.SetActive(false);
        }

        alternativeUIObjects.Clear();
    }

    void SetWorldObjectVisible(bool condition)
    {
        gameObject.SetActive(condition);
    }

    void SetUIObjectVisible(bool condition)
    {
        if (!ValidateReference(interactable)) return;

        if (!ValidateReference(interactable.GetUIObject())) return;

        interactable.GetUIObject().SetActive(condition);
    }

    void SetAlternativeUIObjectVisible(GameObject target, bool condition)
    {
        if (ValidateReference(target))
        {
            target.SetActive(condition);
            return;
        }

        SetUIObjectVisible(condition);
    }

    bool ValidateReference(Object obj)
    {
        if (obj != null) return true;

        Debug.LogWarning($"[{gameObject.name}] Missing reference in Collectible component!", this);
        return false;
    }
}