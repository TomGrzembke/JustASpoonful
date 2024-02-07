using UnityEngine;
using UnityEngine.Events;

public class FoundEvent : MonoBehaviour
{
    [SerializeField] UnityEvent foundEvent;

    public void Found()
    {
        foundEvent?.Invoke();
    }
}
