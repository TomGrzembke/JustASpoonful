using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;

        public float InteractInstigatorAmount => interactableInstigator.Count;
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
        }

        public void DesubscribeInteractable(Interactable interactable)
        {
            interactableInstigator.Remove(interactable);
            interactableDoneInstigator.Add(interactable);

            if (interactableInstigator.Count < 1)
            {
                endButton.SetActive(true);
            }
        }

        public void AddPickupable(Pickupable pickupable)
        {
            currentDropable?.Drop();
            currentDropable = pickupable;
        }
    }
}
