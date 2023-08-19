using UnityEngine;

public class ClosetControl : MonoBehaviour
{
    EventTriggerBehavior eventTriggerBehavior;
    private void Start()
    {
        eventTriggerBehavior = GameObject.Find("Manager").GetComponent<EventTriggerBehavior>();
    }

    public void UIRightOn()
    {
        eventTriggerBehavior.schrankUI_left.SetActive(false);
        eventTriggerBehavior.schrankUI_right.SetActive(true);
    }

    public void UILeftOn()
    {
        eventTriggerBehavior.schrankUI_left.SetActive(true);
        eventTriggerBehavior.schrankUI_right.SetActive(false);
    }
}
