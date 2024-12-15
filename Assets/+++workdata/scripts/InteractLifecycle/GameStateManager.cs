using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public event Action<int> OnInteractablesChanged;
    public int InteractInstigatorAmount => interactableInstigator.Count;
    [SerializeField] List<Interactable> interactableInstigator = new();
    [SerializeField] List<Interactable> interactableDoneInstigator = new();
    [SerializeField] GameObject endButton;
    [SerializeField] Pickupable currentDropable;

    void Awake()
    {
        Instance = this;
    }

    public void SubscribeInteractable(Interactable interactable)
    {
        interactableInstigator.Add(interactable);
        RefreshInsitigators();
    }

    public void DesubscribeInteractable(Interactable interactable)
    {
        if (interactableInstigator.Remove(interactable))
            OnInteractablesChanged?.Invoke(InteractInstigatorAmount);

        interactableDoneInstigator.Add(interactable);

        if (interactableInstigator.Count < 1)
        {
            endButton.SetActive(true);
        }

        RefreshInsitigators();
    }

    public void AddPickupable(Pickupable pickupable)
    {
        if (currentDropable)
            currentDropable.Drop();
        currentDropable = pickupable;
    }

    public void RegisterOnInteractableChanged(Action<int> callback, bool getInstantCallback = false)
    {
        OnInteractablesChanged += callback;
        if (getInstantCallback)
            callback(InteractInstigatorAmount);
    }

    public void RefreshInsitigators()
    {
        interactableInstigator.RemoveAll(x => x == null);
        interactableDoneInstigator.RemoveAll(x => x == null);
    }
}

