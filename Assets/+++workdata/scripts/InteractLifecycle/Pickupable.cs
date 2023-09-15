using UnityEngine;

namespace JustASpoonful
{
    public class Pickupable : MonoBehaviour, IPickupable
    {
        [SerializeField] GameObject uIObject;
        [SerializeField] bool solved;

        public void Pickup()
        {
            gameObject.SetActive(false);

            if (uIObject != null)
                uIObject.SetActive(true);
            else
                Debug.LogWarning(gameObject.name + " has no assigned UIObject");
        }

        public void Drop()
        {
            if (solved)
                gameObject.SetActive(true);

            uIObject.SetActive(false);
        }
    }
}
