using UnityEngine;

namespace JustASpoonful
{
    public class Pickupable : MonoBehaviour, IPickupable
    {
        [SerializeField] Interactable interactable;
        /// <summary> Used when multiple objects are usable for the object </summary>


        public void Pickup()
        {
            gameObject.SetActive(false);

            if (CheckAssigned(interactable))
                interactable.GetUIObject().SetActive(true);

            GameStateManager.Instance.AddPickupable(this);
        }

        public void Pickup(GameObject alternUIObj)
        {
            gameObject.SetActive(false);

            if (CheckAssigned(alternUIObj))
                alternUIObj.SetActive(true);

            else if (CheckAssigned(interactable))
                interactable.GetUIObject().SetActive(true);

            GameStateManager.Instance.AddPickupable(this);
        }

        public void Drop()
        {
            gameObject.SetActive(true);

            if(interactable.solved)
                GetComponent<Collider2D>().enabled = false;

            if (CheckAssigned(interactable))
                if (CheckAssigned(interactable.GetUIObject()))
                    interactable.GetUIObject().SetActive(false);
        }

        public bool CheckAssigned(MonoBehaviour script)
        {
            if (script != null)
                return true;
            else
            {
                Debug.LogWarning("At " + gameObject.name + " has no assigned Interactable");
                return false;
            }
        }

        public bool CheckAssigned(GameObject gO)
        {
            if (gO != null)
                return true;
            else
            {
                Debug.LogWarning("At " + gameObject.name + " has no assigned Interactable");
                return false;
            }
        }
    }
}
