using UnityEngine;
using UnityEngine.Events;

public class EventAfterDelay : MonoBehaviour
{
    /// <summary> Just for debugging Purposes</summary>
    [SerializeField] string functionality;
    [SerializeField] UnityEvent onDelay;

    public void OnDelay(float delay)
    {
        Invoke(nameof(Execute), delay);
    }

    void Execute()
    {
        onDelay?.Invoke();
    }
}
