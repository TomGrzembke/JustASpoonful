using UnityEngine;

public class DisableGameObjectEvent : MonoBehaviour
{
    public void DisableGO() => gameObject.SetActive(false);
}
