using UnityEngine;

public class FishFoodAnimationControl : MonoBehaviour
{
    #region Access
    public GameObject fishFood;
    EventTriggerBehavior eventTriggerBehavior;

    private void Awake()
    {
        eventTriggerBehavior = GameObject.Find("Manager").GetComponent<EventTriggerBehavior>();
    }
    #endregion

    public void FishFoodOnAquActive()
    {
        fishFood.SetActive(true);
        eventTriggerBehavior.StarHoverEnd(GameObject.Find("StarsFishfood"));
        fishFood.GetComponent<PolygonCollider2D>().enabled = false;
    }

    public void SpoonFound()
    {
        eventTriggerBehavior.SpoonAquarium();
    }
}
