using UnityEngine;

namespace JustASpoonful
{
    public class Pickupable : MonoBehaviour, IPickupable
    {
        [SerializeField] Interactable interactable;

        public void Pickup()
        {
            gameObject.SetActive(false);
            if (CheckAssigned(interactable))
                interactable.GetUIObject().SetActive(true);
        }

        public void Drop()
        {
            if (interactable.solved)
                gameObject.SetActive(true);

            if (CheckAssigned(interactable))
                interactable.GetUIObject().SetActive(false);
        }

        public bool CheckAssigned(MonoBehaviour script)
        {
            if (script != null)
                return true;
            else
            {
                Debug.LogWarning("At " + gameObject.name +" has no assigned Interactable");
                return false;
            }
        }
    }
}
