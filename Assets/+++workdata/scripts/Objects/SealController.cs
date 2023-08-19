using UnityEngine;

public class SealController : MonoBehaviour
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
        eventTriggerBehavior.SpoonSeal();
    }
}
