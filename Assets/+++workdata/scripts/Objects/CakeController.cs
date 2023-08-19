using UnityEngine;

public class CakeController : MonoBehaviour
{
    #region Access
    EventTriggerBehavior eventTriggerBehavior;

    private void Awake()
    {
        eventTriggerBehavior = GameObject.Find("Manager").GetComponent<EventTriggerBehavior>();
    }
    #endregion

    public void SpoonFound()
    {
        eventTriggerBehavior.SpoonCake();
    }
}
