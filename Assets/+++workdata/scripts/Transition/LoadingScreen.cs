using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;
    [SerializeField] float fadeTime = 2;
    [SerializeField] CanvasGroup canvasGroup;

    static List<object> loadingInstigator = new();

    void Awake()
    {
        Instance = this;
        loadingInstigator.Clear();
    }
    void Start()
    {
        Initialize();
    }

    public void Show(object instigator)
    {
        loadingInstigator.Add(instigator);
        Show();
    }

    public void Hide(object instigator)
    {
        loadingInstigator.Remove(instigator);

        if (loadingInstigator.Count == 0)
            Hide();

    }

    public void Initialize()
    {
        if (loadingInstigator.Count > 0)
            Show();
        else
            Hide();
    }

    public void Show()
    {
        canvasGroup.alpha = 1;
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(HideCoroutine());
    }

    IEnumerator HideCoroutine()
    {
        float time = 0;
        while (time < fadeTime)
        {
            yield return null;
            time += Time.unscaledDeltaTime;
            canvasGroup.alpha = 1 - Mathf.Clamp01(time / fadeTime);
        }
        canvasGroup.alpha = 0;
    }
}