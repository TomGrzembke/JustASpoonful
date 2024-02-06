using UnityEngine;

public class DisableGameObjectEvent : MonoBehaviour
{
    [SerializeField] bool onStart;
     void Start() => gameObject.SetActive(!onStart);

    public void DisableGO() => gameObject.SetActive(false);
}
