using System.Collections.Generic;
using UnityEngine;

namespace JustASpoonful
{
    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance;
        [SerializeField] List<Interactable> interactableInstigator = new();
        [SerializeField] List<Interactable> interactableDoneInstigator = new();
        [SerializeField] GameObject endButton;

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
    }
}
