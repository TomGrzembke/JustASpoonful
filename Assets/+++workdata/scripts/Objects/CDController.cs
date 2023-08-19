using UnityEngine;

public class CDController : MonoBehaviour
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
        eventTriggerBehavior.SpoonRadio();
    }
}
