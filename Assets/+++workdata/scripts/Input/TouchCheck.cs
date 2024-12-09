using System.Collections;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{
    public static TouchCheck Instance;
    [field: SerializeField] public bool UsedTouch { get; private set; }
    Coroutine touchCheckCor;
    void Awake() => Instance = this;

    void Start()
    {
        touchCheckCor = StartCoroutine(TouchCheckCor());
    }

    IEnumerator TouchCheckCor()
    {
        while (Input.touchCount <= 0)
        {
            yield return null;
        }
        UsedTouch = true;
    }

    public void StopCheck()
    {
        if (touchCheckCor != null)
            StopCoroutine(touchCheckCor);
    }


}
